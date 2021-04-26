<template>
  <el-container class="index-container">
    <el-main>
      <div class="content-container">
        <div class="article" v-html="article"></div>
        <div class="information el-icon-info" @click="openNotification"></div>
      </div>
      <div class="footer-placeholder"></div>
    </el-main>

    <div class="footer" v-if="true">
      <div class="mark-history">
        <el-tag
          class="tags"
          v-for="tag in tags"
          :c-id="tag.id"
          :key="tag.id"
          :color="tag.color"
          @close="removeTags"
          @click="scrollToView"
          closable
        >
          {{ tag.name }}
        </el-tag>
      </div>
      <div class="check-box">
        <el-checkbox v-model="review" disabled>
          <el-tooltip placement="top">
            <div slot="content">综述文献内容较多，文献标记量按照三倍计算</div>
            <el-link type="primary">这是一篇综述性文章</el-link>
          </el-tooltip>
        </el-checkbox>
      </div>
      <div class="btns">
        <el-button type="success" @click="audited" :disabled="!canAudit"
          >通过审核</el-button
        >
        <el-button type="danger" @click="openMenus" :disabled="!canAudit"
          >审核不通过</el-button
        >
      </div>
    </div>

    <el-dialog
      :visible.sync="dialogVisible"
      width="30%"
      center
      class="dialog"
      @closed="closeMenus"
    >
      <div slot="title" class="dialog-title">
        <span>请输入未通过原因描述</span>
      </div>
      <div class="dialog-body">
        <el-link id="selection-tooltip"
          >查看您选中的内容<i class="el-icon-view el-icon--right"></i>
        </el-link>

        <div class="inputer" ref="inputer">
          <el-input
            type="textarea"
            :autosize="{ minRows: 6, maxRows: 20 }"
            placeholder="请输入内容"
            v-model="remark"
          >
          </el-input>
        </div>
      </div>
      <div slot="footer" class="dialog-footer">
        <el-button @click="closeMenus">取 消</el-button>
        <el-button type="primary" @click="unaudited">确 定</el-button>
      </div>
    </el-dialog>
  </el-container>
</template>

<script>
import tippy from 'tippy.js'
import 'tippy.js/dist/tippy.css' // optional for styling
import { ApiClient, ArticleApi, AccountApi, TagArticleStatusEnum } from '@/api'

export default {
  data: function () {
    return {
      articleApi: new ArticleApi(ApiClient.instance),
      accountApi: new AccountApi(ApiClient.instance),
      auditStatusEnum: new TagArticleStatusEnum(),
      remark: '',
      article: '',
      articleId: '',
      tags: [],
      dialogVisible: false,
      canAudit: false,
      review: false,
      user: {},
      tagger: {
        id: 0,
        email: '',
        name: ''
      }
    }
  },
  created () {
    this.articleId = this.$route.params.id
    this.user = JSON.parse(window.localStorage.getItem('user_info') || '{}')

    this.checkStatus().then((flag) => {
      this.canAudit = flag
    }).catch((error) => {
      this.canAudit = false
    })

    this.searchArticle().then((resp) => {
      this.bindTooltip()
    })

    this.getTaggerInfo()
  },
  methods: {
    openMenus (mouse) {
      this.dialogVisible = true
    },
    closeMenus (mouse) {
      this.dialogVisible = false
    },
    scrollToView (e) {
      // 滚动到固定元素
      var id = e.target.getAttribute('c-id')
      document.querySelector(`#mark-id-${id}`).scrollIntoView();
    },
    /**删除页面下方Tag，同时移除文章中对应的标记标签 */
    removeTags (mouse) {
      var tag = mouse.target.parentElement
      // 移除tag
      var id = tag.getAttribute('c-id')
      this.removeTagsItem(id)
      // 减少计数器
      // this.taggedNum -= 1
      // console.log(`减少计数：${this.taggedNum}`)
      console.log(`计数减一。当前：${this.currentTagId}`)
      // 移除页面元素
      this.removeImgTags(id)
      this.removeTextTags(id)
      // 保存操作
      this.saveTags()
    },
    /**删除文章中对应的标记标签。图片标签 */
    removeImgTags (id) {
      // 找到元素
      var img = document.querySelector(`img[c-id="${id}"]`)
      if (img) {
        // 删除属性
        img.classList.remove('tagged', 'tagged-img')
        img.removeAttribute('c-id')
        img.removeAttribute('c-type')
        img.removeAttribute('c-name')
        img.style.borderWidth = '0px'
      }
    },
    /**删除文章中对应的标记标签。文字标签 */
    removeTextTags (id) {
      // 找到元素
      var marks = document.querySelectorAll(`mark[c-id="${id}"]`)
      if (marks.length) {
        // 删除元素
        for (var mark of marks) {
          mark.remove()
        }
      }
    },
    /**移除Tag 数组项 */
    removeTagsItem (id) {
      var i = this.tags.findIndex(s => s.id == id)
      this.tags.splice(i, 1)
    },
    /**保存标记信息 */
    saveTags () {
      // 调用API保存标记信息
      this.article = document.querySelector('.article').innerHTML
      this.articleApi.apiArticleSaveTaggedRecordPost({
        body: {
          id: this.articleId,
          taggedContent: this.article,
          tags: this.tags
        }
      }, (error, data, resp) => {
        if (error) {
          alert(error)
          return
        }

        this.bindTooltip()
      })
    },
    checkStatus () {
      var p = new Promise((resolve, reject) => {
        this.articleApi.apiArticleCheckCanAuditPost({
          articleId: this.articleId
        }, (error, data, resp) => {
          if (error) {
            reject(error)
            return
          }
          if (!data.success || !data.result) {
            reject(false)
            return
          }
          resolve(true)
        })
      })
      return p
    },
    audited () {
      // 通过
      this.checkStatus()
        .then(async () => {
          await this.submitAudited()
        })
        .catch((flag) => {
          alert('禁止审核')
        }).finally(() => {
          this.getNextArticle()
        })
    },
    unaudited () {
      // 不通过
      this.checkStatus()
        .then(async () => {
          await this.submitUnaudited()
        })
        .catch((flag) => {
          alert('禁止审核')
        }).finally(() => {
          this.closeMenus()
          this.getNextArticle()
        })
    },
    submitAudited () {
      var p = new Promise((resolve, reject) => {
        this.articleApi.apiArticleAuditArticlePost({
          body: {
            id: this.articleId,
            status: this.auditStatusEnum.Audited,
            auditorID: this.user.userId
          }
        }, (error, data, resp) => {
          if (error) {
            reject(error)
            alert(error)
            return
          }

          resolve(data)
        })
      })

      return p
    },
    submitUnaudited () {
      var p = new Promise((resolve, reject) => {
        this.articleApi.apiArticleAuditArticlePost({
          body: {
            id: this.articleId,
            status: this.auditStatusEnum.Unsanctioned,
            remark: this.remark,
            auditorID: this.user.userId
          }
        }, (error, data, resp) => {
          if (error) {
            reject(error)
            alert(error)
            return
          }

          resolve(data)
        })
      })

      return p
    },
    searchArticle () {
      // 调用API查询 文章和标记
      var p = new Promise((resolve, reject) => {
        this.articleApi.apiArticleSearchArticlePost({
          articleId: this.articleId
        }, (error, data, resp) => {
          if (error) {
            alert(error)
            reject(error)
            return
          }

          if (data.success) {
            var result = data.result
            this.articleId = result.id
            this.article = result.content
            this.review = result.review
            this.tags = result.tags || []
            resolve(data)
          }

          reject(data)
        })
      })

      return p
    },
    bindTooltip () {
      var elements = document.getElementsByClassName('tagged')
      for (var element of elements) {
        var name = element.getAttribute('c-name')
        var attribute = element.getAttribute('c-attribute')

        tippy(element, {
          content: name + (attribute ? `/${attribute}` : '')
        })
      }
    },
    getNextArticle () {
      this.articleApi.apiArticleGetTaggersCanAuditArticlePost({
        taggerId: this.tagger.id
      }, (error, data, resp) => {
        if (error) {
          alert(error)
          return
        }

        if (data.success) {
          var result = data.result
          alert(`获取下一篇`)
          this.$router.push(`/article/auditarticle/${result.id}`)
        } else {
          alert(`没有可审核文献`)
          this.$router.push(`/article/articlelist`)
        }
      })
    },
    getTaggerInfo () {
      this.accountApi.apiAccountGetTaggerInfoByArticleTaggedRecordIdPost({
        recordId: this.articleId
      }, (error, data, resp) => {
        if (error) {
          alert(error)
          return
        }

        if (data.success) {
          this.tagger.id = data.result.id
          this.tagger.name = data.result.name
          this.tagger.email = data.result.email

          this.openNotification()
        }
      })
    },
    openNotification () {
      var h = this.$createElement
      this.$notify({
        title: '标记员信息',
        message: h('p', null, [
          h('p', null, `标记员ID：${this.tagger.id}`),
          h('p', null, `标记员名称：${this.tagger.name}`),
          h('p', null, `标记员邮箱：${this.tagger.email}`),
        ]),
        offset: 60
      });
    }
  }
}
</script>

<style lang="less" scoped>
  ::selection {
    color: red;
    background: yellow;
  }

  .index-container {
    position: relative;

    .content-container {
      position: relative;

      .article {
        .one {
          border: 1px solid rgb(204, 45, 45);
        }
        .two {
          border: 1px solid rgb(162, 204, 45);
        }
        .three {
          border: 1px solid rgb(45, 74, 204);
        }
      }

      .information {
        position: absolute;
        height: 16px;
        width: 16px;
        top: 5px;
        right: 10px;
        cursor: pointer;
      }
    }

    @footheight: 330px;
    .footer {
      position: fixed;
      height: @footheight;
      width: 100%;
      bottom: 0px;
      // box-shadow: 0 2px 4px rgba(0, 0, 0, 0.12), 0 0 6px rgba(0, 0, 0, 0.04);
      box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
      background-color: #fff;
      padding: 1rem;

      .mark-history {
        width: 85%;
        height: 200px;

        .tags {
          margin: 5px;
        }
      }

      .check-box {
        padding: 0.5rem 0;
        border-top: 1px solid rgba(0, 0, 0, 0.1);
        border-bottom: 1px solid rgba(0, 0, 0, 0.1);
      }

      .btns {
        position: absolute;
        bottom: 10px;
      }
    }

    .footer-placeholder {
      height: @footheight;
      width: 100%;
    }
  }
</style>

<style lang="less">
  .el-dialog__body {
    text-align: inherit !important;
  }
</style>
