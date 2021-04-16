<template>
  <!-- 标记计数从 1 开始 -->
  <!-- 标记计数从 1 开始 -->
  <!-- 标记计数从 1 开始 -->
  <el-container class="index-container">
    <el-main>
      <div>
        <div
          class="article"
          @mouseup.right="openMenu"
          v-html="article.content"
        ></div>
      </div>
      <div class="footer-placeholder"></div>
    </el-main>

    <div class="footer">
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
        <el-checkbox v-model="review" @change="setReview">
          <el-tooltip placement="top">
            <div slot="content">综述文献内容较多，文献标记量按照三倍计算</div>
            <el-link type="primary">这是一篇综述性文章</el-link>
          </el-tooltip>
        </el-checkbox>
      </div>
      <div class="btns">
        <el-button type="success" @click="submitAudit">提交审核</el-button>
        <el-button type="danger" @click="skipArticle">跳过文章</el-button>
      </div>
    </div>

    <el-dialog
      :visible.sync="dialog.visible"
      width="30%"
      center
      class="dialog"
      @closed="closeMenu"
    >
      <div slot="title" class="dialog-title">
        <span>{{ dialog.title }}</span>
      </div>
      <div class="dialog-body">
        <el-link id="selection-tooltip"
          >查看您选中的内容<i class="el-icon-view el-icon--right"></i>
        </el-link>

        <div class="cascader" v-show="dialog.isCascader">
          <el-cascader
            v-model="currentCascade"
            :options="cascade"
            :props="{ expandTrigger: 'hover' }"
          ></el-cascader>
        </div>

        <div class="inputer" v-show="dialog.isInput">
          <el-checkbox v-model="result">
            <el-tooltip placement="top">
              <div slot="content">表现适配体性能的图片</div>
              <el-link type="primary">这是一张表征图片</el-link>
            </el-tooltip>
          </el-checkbox>

          <el-input
            type="textarea"
            :autosize="{ minRows: 6, maxRows: 20 }"
            placeholder="请输入内容"
            v-model="imgTagContent"
            :disabled="result"
          >
          </el-input>
        </div>
      </div>
      <div slot="footer" class="dialog-footer">
        <el-button @click="closeMenus">取 消</el-button>
        <el-button type="primary" @click="addTags">确 定</el-button>
      </div>
    </el-dialog>
  </el-container>
</template>

<script>
import tippy from 'tippy.js'
import 'tippy.js/dist/tippy.css' // optional for styling
import { ApiClient, ArticleApi } from '@/api'

export default {
  data: function () {
    return {
      api: new ArticleApi(ApiClient.instance),
      article: {
        id: 0,
        isReview: false,
        content: '',
        tags: []
      },
      currentTag: {
        id: 0,
        type: '',
        content: '',
        color: ''
      },
      dialog: {
        title: '',
        visible: false,
        isInput: false,
        isCascader: false
      },
      tippy: {
        self: {},
        tippyContent: ''
      },
      selection: {
        anchorNode: null,
        anchorOffset: 0,
        focusNode: null,
        focusOffset: 0,
        isCollapsed: false,
        rangeCount: 0,
        type: '',
        content: '',
        isImg: false
      },
      cascade: [{
        value: 'AptamerType',
        label: 'AptamerType',
        color: '#FFFFCC',
        type: 'T'
      }, {
        value: 'AptamerName',
        label: 'AptamerName',
        color: '#CCFFFF',
        type: 'T'
      }, {
        value: 'Sample',
        label: 'Sample',
        color: '#FFCCCC',
        type: 'T'
      }, {
        value: 'Target',
        label: 'Target',
        type: 'T',
        children: [{
          value: 'Protein',
          label: 'Protein',
          color: '#99CCCC',
          type: 'A'
        }, {
          value: 'Compound',
          label: 'Compound',
          color: '#FFCC99',
          type: 'A'
        }, {
          value: 'Virus',
          label: 'Virus',
          color: '#FF9999',
          type: 'A'
        }, {
          value: 'Cells',
          label: 'Cells',
          color: '#996699',
          type: 'A'
        }, {
          value: 'Ion',
          label: 'Ion',
          color: '#CC9999',
          type: 'A'
        }, {
          value: 'Other',
          label: 'Other',
          color: '#CCCC99',
          type: 'A'
        }]
      }, {
        value: 'Affinity',
        label: 'Affinity',
        color: '#FFFF99',
        type: 'T'
      }, {
        value: 'Sequence',
        label: 'Sequence',
        color: '#CCCCFF',
        type: 'T'
      }, {
        value: 'ScreenMethod',
        label: 'ScreenMethod',
        color: '#0099CC',
        type: 'T'
      }, {
        value: 'ScreenCondition',
        label: 'ScreenCondition',
        color: '#CCCCCC',
        type: 'T'
      }, {
        value: 'BindingBuffer',
        label: 'BindingBuffer',
        color: '#FF6666',
        type: 'T'
      }, {
        value: 'Application',
        label: 'Application',
        color: '#FF9966',
        type: 'T'
      }, {
        value: 'References',
        label: 'References',
        color: '#CC9966',
        type: 'T'
      }],
      currentCascade: []
    }
  },
  created () {
    this.disableDefaultMouseRight()
  },
  computed: {
    nextTagId () {
      var ids = this.tags.map(s => parseInt(s.id))
      var next = ids.length ? Math.max.apply(Math, ids) + 1 : 1
      return next
    },
    currentTagId () {
      var ids = this.tags.map(s => parseInt(s.id))
      var current = ids.length ? Math.max.apply(Math, ids) : 1
      return current
    },
    lastTagId () {
      var ids = this.tags.map(s => parseInt(s.id)).sort()
      var last = ids.length ? ids[ids.length - 2] : 1
      return last
    }
  },
  methods: {
    /**禁用默认右键菜单 */
    disableDefaultMouseRight () {
      // 禁用默认右键菜单
      if (document.addEventListener) {
        document.addEventListener('contextmenu', function (e) {
          // alert(1)
          // alert("You've tried to open context menu")  //here you draw your own menu
          e.preventDefault()
        }, false)
      } else {
        document.attachEvent('oncontextmenu', function () {
          // alert(2)
          // alert("You've tried to open context menu")
          window.event.returnValue = false
        })
      }
    },
    /**根据字符串获取下拉列表中value相等的对象 */
    getCascaderObj (val, opt) {
      return val.map(function (value, index, array) {
        for (var itm of opt) {
          if (itm.value === value) {
            opt = itm.children
            return itm
          }
        }
        return null
      })
    },
    /**获取选中的节点类型 */
    getNodeType (node) {
      switch (node.nodeType) {
        case 1:
          return 'element'
        case 3:
          return 'node'
        default:
          return 'node'
      }
    },
    /**
     * 获取鼠标划取对象
     * 或获取鼠标右键目标
     */
    getSelection (mouse) {
      var t = window.getSelection()
      window.t = t

      try {
        // 鼠标划中了一片区域
        // 或者鼠标在文字上点击右键
        var r = t.getRangeAt(0)
        this.selection.anchorNode = r.startContainer
        this.selection.anchorOffset = r.startOffset
        this.selection.focusNode = r.endContainer
        this.selection.focusOffset = r.endOffset
        this.selection.isCollapsed = t.isCollapsed
        this.selection.rangeCount = t.rangeCount
        this.selection.type = t.type
        this.selection.content = t.toString()
        console.log(`选中文字：${t.toString()}`)
      } catch (error) {
        // 鼠标没有划中区域。
        // 或者鼠标在图片上点击右键
        // 需要为判断是否是右击图片提供数据
        this.selection.anchorNode = t.anchorNode
        this.selection.anchorOffset = t.anchorOffset
        this.selection.focusNode = t.focusNode
        this.selection.focusOffset = t.focusOffset
        this.selection.isCollapsed = t.isCollapsed
        this.selection.rangeCount = t.rangeCount
        this.selection.type = t.type
        this.selection.content = t.toString()
        console.log(`选中非文字：${t.toString()}`)
      }

      return t
    },
    /**选中文字的Selection设置 */
    getTextSelection (mouse, wSelection) {
      var r = wSelection.getRangeAt(0) // 抛出异常则代表不是文字选中
      this.selection.anchorNode = r.startContainer
      this.selection.anchorOffset = r.startOffset
      this.selection.focusNode = r.endContainer
      this.selection.focusOffset = r.endOffset
      this.selection.isCollapsed = t.isCollapsed
      this.selection.rangeCount = t.rangeCount
      this.selection.type = t.type
      this.selection.content = t.toString()
    },
    openMenu (mouse) {
      this.dialog.visible = true
    },
    closeMenu () {
      this.dialog.visible = false
    },

    /**保存标记信息 */
    submitTagged () {
      // 调用API保存标记信息
      this.article = document.querySelector('.article').innerHTML
      this.api.apiArticleSaveTaggedRecordPost({
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
    submitAudit () {
      // 调用API提交文章审核
      this.api.apiArticleSubmitAuditPost({
        articleId: this.articleId
      }, (error, data, resp) => {
        if (error) {
          alert(error)
          return
        }

        if (data.success) {
          if (data.result) {
            alert('获取下一篇')
            // 获取下一篇
            this.searchArticle()
          }
        }
      })
    },
    searchArticle () {
      // 调用API获取文章信息
      var p = new Promise((resolve, reject) => {
        this.api.apiArticleDistributeArticlePost({
          taggerId: this.user.userId
        }, (error, data, resp) => {
          if (error) {
            alert(error)
            reject(error)
            return
          }

          if (data.success) {
            var result = data.result
            if (result === null) {
              this.$router.push('/article/articlelist')
              resolve(data)
            }
            this.articleId = result.id
            this.article = result.content
            this.review = result.review
            this.tags = result.tags || []
            console.log(`当前计数：${this.currentTagId}`)
            // this.taggedNum = this.tags.length
            resolve(data)
          } else {
            alert(data.errorMsg)
            this.$router.push('/article/articlelist')
            reject(data)
          }
          reject(data)
        })
      })

      return p
    },
    skipArticle () {
      var h = this.$createElement
      this.$msgbox({
        title: '提示',
        message: h('p', null, [
          h('p', null, '此操作将跳过该论文, 是否继续?'),
          h('p', { style: 'color:red' }, '被跳过的文章将会被审核，请勿恶意跳过文章')
        ]),
        showCancelButton: true,
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        this.api.apiArticleSetUnavailArticlePost({
          articleId: this.articleId
        }, (error, data, resp) => {
          if (error) {
            alert(error)
            return
          }

          if (data.success) {
            this.$message({
              type: 'success',
              message: '跳过成功!'
            })
            this.searchArticle()
          } else {
            this.$message({
              type: 'warning',
              message: '跳过失败!'
            })
          }
        })
      }).catch(() => {
        this.$message({
          type: 'info',
          message: '已取消操作'
        });
      })
    },
    setReview () {
      // 设置为综述标志
      this.api.apiArticleSetReviewArticlePost({
        articleId: this.articleId,
        review: this.review
      }, (error, data, resp) => {
        if (error) {
          alert(error)
          return
        }
      })
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
        // max-width: 104rem;
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
  ::selection {
    color: red;
    background: yellow;
  }

  .el-dialog__body {
    text-align: inherit !important;
  }
</style>
