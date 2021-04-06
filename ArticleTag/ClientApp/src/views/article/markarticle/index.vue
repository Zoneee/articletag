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
        <div class="article" @mouseup.right="openMenus" v-html="article"></div>
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
          closable
        >
          {{ tag.name }}
        </el-tag>
      </div>
      <div class="btns">
        <el-button type="success" @click="submitAudit">提交审核</el-button>
        <el-button type="danger" @click="skipArticle">跳过文章</el-button>
      </div>
    </div>

    <el-dialog
      :visible.sync="dialogVisible"
      width="30%"
      center
      class="dialog"
      @opened="setSelectionTooltip"
      @closed="closeMenus"
    >
      <div slot="title" class="dialog-title">
        <span>{{ dialogTitle }}</span>
      </div>
      <div class="dialog-body">
        <el-link id="selection-tooltip"
          >查看您选中的内容<i class="el-icon-view el-icon--right"></i>
        </el-link>

        <div class="cascader" v-show="cascaderVisible">
          <el-cascader
            v-model="value"
            :options="options"
            :props="{ expandTrigger: 'hover' }"
          ></el-cascader>
        </div>

        <div class="inputer" ref="inputer" v-show="inputerVisible">
          <el-input
            type="textarea"
            :autosize="{ minRows: 6, maxRows: 20 }"
            placeholder="请输入内容"
            v-model="imgTagContent"
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
      taggedNum: 0,
      selection: {
        anchorNode: null,
        anchorOffset: 0,
        focusNode: null,
        focusOffset: 0,
        isCollapsed: false,
        rangeCount: 0,
        type: '',
        content: ''
      },
      value: [],
      imgTagContent: '',
      dialogTitle: '',
      dialogVisible: false,
      cascaderVisible: false,
      inputerVisible: false,
      dialogTippy: null,
      dialogTippyContent: '',
      tags: [],
      article: '',
      articleId: 0,
      options: [{
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
      user: {}
    }
  },
  created () {
    this.user = JSON.parse(window.localStorage.getItem('user_info') || '{}')

    this.searchArticle().then((resp) => {
      this.bindTooltip()
    })

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
  methods: {
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
    /**获取鼠标划取对象 */
    getSelection () {
      var t = window.getSelection()
      window.t = t
      console.log(t.anchorOffset)
      console.log(t.focusOffset)
      if (t.isCollapsed) {
        console.log('未选中内容')
        alert('未选中内容')
        return
      }
      console.log(`选中：${t.toString()}`)

      var r = t.getRangeAt(0)
      this.selection.anchorNode = r.startContainer
      this.selection.anchorOffset = r.startOffset
      this.selection.focusNode = r.endContainer
      this.selection.focusOffset = r.endOffset
      this.selection.isCollapsed = t.isCollapsed
      this.selection.rangeCount = t.rangeCount
      this.selection.type = t.type
      this.selection.content = t.toString()

      return t
    },
    /**设置Dialog中Tip信息 */
    setSelectionTooltip () {
      if (!this.dialogTippy) {
        this.dialogTippy = tippy('#selection-tooltip', {
          content: this.dialogTippyContent
        })
      } else {
        this.dialogTippy[0].setContent(this.dialogTippyContent)
      }
    },
    /**弹出标记菜单Dialog */
    openMenus (mouse) {
      var t = this.getSelection()
      if (!t) {
        return
      }

      if (this.selection.anchorNode === this.selection.focusNode && !this.selection.content && !this.selection.isCollapsed) {
        // 打开输入菜单
        this.openInputer(mouse)
      } else {
        // 打开下拉菜单
        this.openCascader(mouse)
      }
    },
    /**关闭标记菜单Dialog */
    closeMenus (mouse) {
      this.dialogVisible = false
      this.cascaderVisible = false
      this.inputerVisible = false
    },
    /**打开选择行为的标记菜单Dialog */
    openCascader (mouse) {
      this.dialogVisible = true
      this.cascaderVisible = true
      this.dilaogTitle = '请选择靶标'

      this.dialogTippyContent = this.selection.content
    },
    /**打开输入行为的标记菜单Dialog */
    openInputer (mouse) {
      this.dialogVisible = true
      this.inputerVisible = true
      this.dilaogTitle = '请输入序列'

      var i = this.selection.anchorOffset < this.selection.focusOffset ? this.selection.anchorOffset : this.selection.focusOffset
      var targetElement = this.selection.anchorNode.childNodes[i]

      this.dialogTippyContent = targetElement.id || '暂无ID'
    },
    /**设置标记 */
    setTag (tags) {
      var id = ++this.taggedNum

      if (this.selection.isCollapsed) {
        // 未选中内容
        return
      } else if (this.selection.anchorNode === this.selection.focusNode) {
        // 选中一个标签
        var i = this.selection.anchorOffset < this.selection.focusOffset ? this.selection.anchorOffset : this.selection.focusOffset
        this.setNodeTag(this.selection.anchorNode, i, tags, id, null, null, true)
      } else {
        // 选中跨标签内容
        this.setNodeTag(this.selection.anchorNode, this.selection.anchorOffset, tags, id, '{', 'ts', false)
        this.setNodeTag(this.selection.focusNode, this.selection.focusOffset, tags, id, '}', 'te', false)
      }
    },
    /**设置节点标记 */
    setNodeTag (node, nodeOffset, tags, id, content, tagType, isInner) {
      switch (node.nodeType) {
        case 1:
          // 设置y元素
          if (node.tagName.toLowerCase() === 'img') {
            this.setImgTag(node, nodeOffset, tags, id)
          } else {
            this.setElementTag(node, nodeOffset, tags, id, content, tagType)
          }
          break
        case 3:
          // 设置内容
          if (isInner) {
            this.setInnerTag(tags, id)
            return
          }
          this.setTextTag(node, nodeOffset, tags, id, content, tagType)
          break
      }
    },
    /**
     * 单个节点的文本标记
     * 节点尾部的换行标记
     */
    setElementTag (node, length, tags, id, content, tagType) {
      var targetElement = node.childNodes[length]
      this.setTextTag(targetElement, length, tags, id, content, tagType)
    },
    /**
     * 单个节点的文本标记
     * 跨标签的文本标记
     */
    setTextTag (node, length, tags, id, content, tagType) {
      var beforeText = node.data.substr(0, length)
      var afterText = node.data.substr(length)

      var beforeNode = document.createTextNode(beforeText)
      var afterNode = document.createTextNode(afterText)
      var tagElement = this.createMark(content, id)
      tagElement.classList.add('tagged', 'tagged-node')
      tagElement.style.backgroundColor = tags[1] ? tags[1].color : tags[0].color
      tagElement.setAttribute('tagType', tagType)
      this.setAttributes(tagElement, tags, id)

      node.replaceWith(beforeNode, tagElement, afterNode)
    },
    /**
     * 单个节点的图片标记
     * 图片标记不区分起始和结束节点
     */
    setImgTag (node, nodeIndex, tags, id) {
      // var markElement = this.createMark('', tags)
      // markElement.classList.add('tagged', 'tagged-img')
      // markElement.setAttribute('c-id', id)
      // markElement.setAttribute('c-type', 'IMG')
      // markElement.setAttribute('c-name', this.imgTagContent)

      // var targetElement = node.childNodes[nodeIndex]

      // targetElement.replaceWith(markElement)
      // markElement.appendChild(targetElement)

      var targetElement = node.childNodes[nodeIndex]
      targetElement.classList.add('tagged', 'tagged-img')
      targetElement.setAttribute('c-id', id)
      targetElement.setAttribute('c-type', 'IMG')
      targetElement.setAttribute('c-name', this.imgTagContent)
      targetElement.style.borderStyle = 'solid'
      targetElement.style.borderColor = 'yellow'
      targetElement.style.borderWidth = '5px'
    },
    /**
     * 单个节点内部的文本标记
     * 不跨标签的文本标记
     * 不跨标签的需要起始节点和结束节点共同参与标记
     */
    setInnerTag (tags, id) {
      var selectedText = this.selection.content
      var beforeText = this.selection.anchorNode.data.substr(0, this.selection.anchorOffset)
      var afterText = this.selection.anchorNode.data.substr(this.selection.focusOffset)
      var beforeNode = document.createTextNode(beforeText)
      var afterNode = document.createTextNode(afterText)
      var selectedNode = document.createTextNode(selectedText)

      var ts = this.createMark('{', tags)
      ts.classList.add('tagged', 'tagged-node')
      ts.style.backgroundColor = tags[1] ? tags[1].color : tags[0].color
      ts.setAttribute('c-type', 'ts')
      this.setAttributes(ts, tags, id)

      var te = this.createMark('}', tags)
      te.classList.add('tagged', 'tagged-node')
      te.style.backgroundColor = tags[1] ? tags[1].color : tags[0].color
      te.setAttribute('c-type', 'te')
      this.setAttributes(te, tags, id)

      this.selection.anchorNode.replaceWith(beforeNode, ts, selectedNode, te, afterNode)
    },
    /**绑定历史标记节点Tip事件 */
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
    /**创建标记节点 */
    createMark (content, tag) {
      var mark = document.createElement('mark')
      mark.innerHTML = content
      mark.style.backgroundColor = tag.color
      return mark
    },
    /**设置标记节点Attribute */
    setAttributes (element, tag, id) {
      if (tag.length === 1) {
        element.setAttribute('c-id', id)
        element.setAttribute('c-type', tag[0].type)
        element.setAttribute('c-name', tag[0].value)
      } else if (tag.length === 2) {
        element.setAttribute('c-id', id)
        element.setAttribute('c-type', tag[0].type)
        element.setAttribute('c-name', tag[0].value)
        element.setAttribute('c-attribute', tag[1].value)
      }
    },
    /**添加页面下方Tag */
    addTags () {
      var tags = this.getCascaderObj(this.value, this.options)

      this.setTag(tags)

      if (tags.length) {
        this.tags.push({
          id: this.taggedNum.toString(),
          name: tags.map(s => s.label).join('/'),
          color: tags[1] ? tags[1].color : tags[0].color,
          // selection: this.selection
        })
      } else {
        this.tags.push({
          id: this.taggedNum.toString(),
          name: this.imgTagContent,
          color: 'yellow',
          // selection: this.selection
        })
      }
      this.selection = {}
      this.value = []
      this.imgTagContent = ''

      this.saveTags()
      this.closeMenus()
    },
    /**删除页面下方Tag，同时移除文章中对应的标记标签 */
    removeTags (mouse) {
      var tag = mouse.target.parentElement
      // 移除tag
      var id = tag.getAttribute('c-id')
      var i = this.tags.findIndex(s => s.id == id)
      this.tags.splice(i, 1)
      // 移除页面元素
      this.removeImgTags(id)
      this.removeTextTags(id)
      // 保存操作
      this.saveTags()
    },
    /**删除页面下方Tag，同时移除文章中对应的标记标签。图片标签 */
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
    /**删除页面下方Tag，同时移除文章中对应的标记标签。文字标签 */
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
    /**保存标记信息 */
    saveTags () {
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
            this.articleId = result.id
            this.article = result.content
            this.tags = result.tags || []
            this.taggedNum = this.tags.length
            resolve(data)
          } else {
            alert(data.errorMsg)
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
  ::selection {
    color: red;
    background: yellow;
  }

  .el-dialog__body {
    text-align: inherit !important;
  }
</style>
