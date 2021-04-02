<template>
  <!-- 不允许跨标签标记 -->
  <!-- 不允许跨标签标记 -->
  <!-- 不允许跨标签标记 -->
  <!-- 不允许跨标签标记 -->
  <!-- 不允许跨标签标记 -->
  <!-- 不允许跨标签标记 -->
  <!-- double Tag -->

  <el-container class="index-container">
    <el-main>
      <div>
        <div class="article" v-html="article"></div>
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
        >
          {{ tag.name }}
        </el-tag>
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
import { ApiClient, ArticleApi, TagArticleStatusEnum } from '@/api'

export default {
  data: function () {
    return {
      api: new ArticleApi(ApiClient.instance),
      auditStatusEnum: new TagArticleStatusEnum(),
      remark: '',
      article: '',
      articleId: '',
      tags: [],
      dialogVisible: false,
      canAudit: false,
      user: {}
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
  },
  methods: {
    openMenus (mouse) {
      this.dialogVisible = true
    },
    closeMenus (mouse) {
      this.dialogVisible = false
    },
    checkStatus () {
      var p = new Promise((resolve, reject) => {
        this.api.apiArticleCheckCanAuditPost({
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
      this.checkStatus().then((flag) => {
        this.api.apiArticleAuditArticlePost({
          body: {
            id: this.articleId,
            status: this.auditStatusEnum.Audited,
            auditorID: this.user.userId
          }
        }, (error, data, resp) => {
          if (error) {
            alert(error)
            return
          }
        })
      }).catch((flag) => {
        alert('禁止审核')
      })
    },
    unaudited () {
      // 不通过
      this.checkStatus().then((flag) => {
        this.api.apiArticleAuditArticlePost({
          body: {
            id: this.articleId,
            status: this.auditStatusEnum.Unsanctioned,
            remark: this.remark,
            auditorID: this.user.userId
          }
        }, (error, data, resp) => {
          if (error) {
            alert(error)
            return
          }
        })
      }).catch((flag) => {
        alert('禁止审核')
      }).finally(() => {
        this.closeMenus()
      })
    },
    searchArticle () {
      // 调用API查询 文章和标记
      var p = new Promise((resolve, reject) => {
        this.api.apiArticleSearchArticlePost({
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

    .footer {
      position: fixed;
      height: 300px;
      width: 100%;
      bottom: 0px;
      // box-shadow: 0 2px 4px rgba(0, 0, 0, 0.12), 0 0 6px rgba(0, 0, 0, 0.04);
      box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
      background-color: #fff;

      .mark-history {
        height: 220px;
        border-bottom: 1px solid rgba(0, 0, 0, 0.1);
        padding: 1rem;

        .tags {
          margin: 5px;
        }
      }

      .btns {
        position: absolute;
        bottom: 10px;
        // border-top: 1px solid rgba(0, 0, 0, 0.1);
        padding: 1rem;
      }
    }

    .footer-placeholder {
      height: 300px;
      width: 100%;
      // border: 1px solid rgb(236, 12, 150);
    }
  }
</style>

<style lang="less">
  .el-dialog__body {
    text-align: inherit !important;
  }
</style>
