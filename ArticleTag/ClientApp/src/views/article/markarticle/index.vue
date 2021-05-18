<template>
  <!-- 标记计数从 1 开始 -->
  <!-- 标记计数从 1 开始 -->
  <!-- 标记计数从 1 开始 -->
  <el-container class="index-container">
    <el-main>
      <div>
        <div class="article" v-html="article" @mouseup.right="openMenus"></div>
        <div class="information el-icon-info" @click="openNotification"></div>
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
      <div class="btns" v-if="user.role != roleEnum.Auditor">
        <el-button type="success" @click="submitAudit">提交审核</el-button>
        <el-button type="danger" @click="skipArticle">跳过文章</el-button>
      </div>
      <div class="btns" v-if="user.role == roleEnum.Auditor">
        <!-- 函数待实现 -->
        <el-button type="success" @click="audited">通过审核</el-button>
        <!-- 函数待实现 -->
        <el-button type="danger" @click="openAuditMenus">审核不通过</el-button>
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
    <el-dialog
      :visible.sync="auditDialogVisible"
      width="30%"
      center
      class="dialog"
      @closed="closeAuditMenus"
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
import { ApiClient, ArticleApi, AccountApi, TagArticleStatusEnum, TagRoleEnum } from '@/api'

export default {
  data: function () {
    return {
      articleApi: new ArticleApi(ApiClient.instance),
      accountApi: new AccountApi(ApiClient.instance),
      auditStatusEnum: new TagArticleStatusEnum(),
      roleEnum: new TagRoleEnum(),
      taggedNum: 0,
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
      value: [],
      /**记录当前编辑元素的TagId */
      currentEditId: 0,
      currentEditFlag: false,
      imgTagContent: '',
      dialogTitle: '',
      dialogVisible: false,
      auditDialogVisible: false,
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
      /**登录者信息 */
      user: {},
      review: false,
      result: false,
      remark: '',
      /**标记员信息 */
      tagger: {
        id: 0,
        email: '',
        name: ''
      }
    }
  },
  created () {
    this.user = JSON.parse(window.localStorage.getItem('user_info') || '{}')

    if (this.user.role === this.roleEnum.Auditor && this.$route.query.articleId) {
      this.searchArticleByAuditor().then(() => this.bindTooltip())
    } else {
      this.searchArticle().then(() => this.bindTooltip())
    }

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
  watch: {
    $route (to, from) {
      if (this.user.role === this.roleEnum.Auditor && this.$route.query.articleId) {
        this.searchArticleByAuditor().then(() => this.bindTooltip())
      } else {
        this.searchArticle().then(() => this.bindTooltip())
      }
    }
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
    // 以下是页面操作相关
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
      console.log(`选中：${t.toString()}`)

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
      }

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
      if (!t || (t.isCollapsed && mouse.target.tagName.toLowerCase() != 'img')) {
        return
      }

      // 设置图片标记
      this.selection.isImg = mouse.target.tagName.toLowerCase() === 'img'

      if (this.selection.anchorNode === this.selection.focusNode && !this.selection.content && !this.selection.isCollapsed || mouse.target.tagName.toLowerCase() === 'img') {
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
      this.currentEditId = 0
      this.currentEditFlag = false
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

      if (!this.selection.isCollapsed) {
        var i = this.selection.anchorOffset < this.selection.focusOffset ? this.selection.anchorOffset : this.selection.focusOffset
        var targetElement = this.selection.anchorNode.childNodes[i]
        this.dialogTippyContent = targetElement.id || '暂无ID'
      } else {
        var target = mouse.target
        if (target.tagName.toLowerCase() === 'img') {
          this.dialogTippyContent = target.id || '暂无ID'
          this.selection.anchorNode = target
          var id = target.getAttribute('c-id')
          var content = target.getAttribute('c-name')
          this.imgTagContent = content
          this.currentEditId = id
        }
      }
    },
    /**设置标记 */
    setTag (tags) {
      // var id = ++this.taggedNum
      var id = this.nextTagId
      console.log(`计数加一。当前：${this.currentTagId}，使用：${this.nextTagId}`)

      if (this.selection.isCollapsed) {
        // 未选中内容
        // 或者右键了图片
        if (this.selection.isImg) {
          this.setNodeTag(this.selection.anchorNode, 0, tags, id, null, null, false)
        }
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
            if (this.result) {
              this.imgTagContent = '检测效果图片'
              this.setImgTag(node, 0, tags, id, this.imgTagContent)
            } else if (this.selection.isCollapsed) {
              this.setImgTag(node, 0, tags, id, this.imgTagContent)
            } else {
              var targetElement = node.childNodes[nodeOffset]
              this.setImgTag(targetElement, nodeOffset, tags, id, this.imgTagContent)
            }
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
      tagElement.id = `mark-id-${id}`
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
    setImgTag (node, nodeIndex, tags, id, content) {
      // var targetElement = node.childNodes[nodeIndex]
      // targetElement.classList.add('tagged', 'tagged-img')
      // targetElement.setAttribute('c-id', id)
      // targetElement.setAttribute('c-type', 'IMG')
      // targetElement.setAttribute('c-name', content)
      // targetElement.style.borderStyle = 'solid'
      // targetElement.style.borderColor = 'yellow'
      // targetElement.style.borderWidth = '5px'

      var sourceId = node.getAttribute('c-id')
      node.classList.add('tagged', 'tagged-img')
      if (!sourceId) {
        node.id = `mark-id-${id}`
        node.setAttribute('c-id', id)
      } else {
        // this.taggedNum--
        this.currentEditFlag = true
        console.log(`更新img内容，计数应该减一。当前：${this.currentTagId}，应当：${this.lastTagId}`)
      }
      node.setAttribute('c-type', 'IMG')
      node.setAttribute('c-name', content)
      node.style.borderStyle = 'solid'
      node.style.borderColor = 'yellow'
      node.style.borderWidth = '5px'
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
      ts.id = `mark-id-${id}`
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
    // 以下是Tag相关
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
    /**添加页面下方Tag */
    addTags () {
      var tags = this.getCascaderObj(this.value, this.options)

      this.setTag(tags)

      // 判断是否有是修改
      var index = this.tags.findIndex(s => s.id == this.currentEditId)
      if (index === -1) {
        this.addTagsItem(this.nextTagId, tags)
      } else {
        this.editTags(this.currentEditId)
      }

      console.log(`当前Tag数组：`)
      console.log(this.tags)
      this.selection = {}
      this.value = []
      this.imgTagContent = ''

      this.saveTags()
      this.closeMenus()
    },
    addTagsItem (id, tags) {
      if (tags.length) {
        this.tags.push({
          // id: this.taggedNum.toString(),
          // id: this.selection.isImg ? this.lastTagId : this.currentEditId,
          id: id.toString(),
          name: tags.map(s => s.label).join('/'),
          color: tags[1] ? tags[1].color : tags[0].color,
          // selection: this.selection
        })
      } else {
        this.tags.push({
          // id: this.taggedNum.toString(),
          // id: this.selection.isImg ? this.lastTagId : this.currentEditId,
          id: id.toString(),
          name: this.imgTagContent,
          color: 'yellow',
          // selection: this.selection
        })
      }
    },
    editTags (id) {
      var elements = document.querySelectorAll(`mark[c-id="${id}"],img[c-id="${id}"]`)
      if (elements.length <= 0) {
        // 无效操作
        return false
      }
      var tagName = elements[0].tagName
      if (tagName.toLowerCase() === 'mark') {
        // 文字操作
        // 只操作第一个元素
        var element = elements[0]
      } else if (tagName.toLowerCase() === 'img') {
        // 图片元素
        var element = elements[0]
        // 修改文中标签内容
        this.editImgTags(id, this.imgTagContent)
        // 修改下方Tag
        var id = element.getAttribute('c-id')
        this.editTagsItem(id, this.imgTagContent)
      }
    },
    /**修改页面下方Tag */
    editTagsItem (id, content) {
      var index = this.tags.findIndex(s => s.id == id)
      var tag = this.tags[index]
      tag.name = content
    },
    /**修改文章中对应的标记标签。图片标签 */
    editImgTags (id, content) {
      // 找到元素
      var img = document.querySelector(`img[c-id="${id}"]`)
      if (img) {
        img.setAttribute('c-name', content)
        return true
      } else {
        return false
      }
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
    scrollToView (e) {
      // 滚动到固定元素
      var id = e.target.getAttribute('c-id')
      document.querySelector(`#mark-id-${id}`).scrollIntoView();
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
    // 以下是提交相关
    submitAudit () {
      // 调用API提交文章审核
      this.articleApi.apiArticleSubmitAuditPost({
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
        } else {
          alert('提交审核异常')
          console.log('标记员提交审核异常')
        }
      })
    },
    searchArticleByAuditor () {
      var articleId = this.$route.query.articleId

      var p = new Promise((resolve, reject) => {
        this.articleApi.apiArticleSearchArticlePost({
          articleId: articleId
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
            this.getTaggerInfo()
            console.log(this.articleId)
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
    searchArticle () {
      // 调用API获取文章信息
      var p = new Promise((resolve, reject) => {
        this.articleApi.apiArticleDistributeArticlePost({
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
        this.articleApi.apiArticleSetUnavailArticlePost({
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
      this.articleApi.apiArticleSetReviewArticlePost({
        articleId: this.articleId,
        review: this.review
      }, (error, data, resp) => {
        if (error) {
          alert(error)
          return
        }
      })
    },
    // 以下是审核相关功能
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
          debugger
          await this.submitAudited()
          this.getNextArticle()
        })
        .catch((flag) => {
          alert('提交审核状态异常')
          console.log('审核员提交审核通过状态异常')
        })
    },
    unaudited () {
      // 不通过
      this.checkStatus()
        .then(async () => {
          debugger
          await this.submitUnaudited()
          this.closeAuditMenus()
          this.getNextArticle()
        })
        .catch((flag) => {
          alert('提交审核状态异常')
          console.log('审核员提交审核不通过状态异常')
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
            console.error(error)
            alert(error)
            return
          }
          console.log(resp)
          resolve(data)
        })
      })

      return p
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
          alert(`获取下一篇待审核的文章`)
          this.$router.push({
            path: `/article/markarticle`,
            query: { articleId: result.id }
          })
        } else {
          alert(`没有可审核文章`)
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
    },
    openAuditMenus (mouse) {
      this.auditDialogVisible = true
    },
    closeAuditMenus (mouse) {
      this.auditDialogVisible = false
    },
  }
}
</script>

<style lang="less" scoped>
  .index-container {
    position: relative;
    .article {
      ::selection {
        color: red;
        background: yellow;
      }

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

    @footheight: 200px;
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
        height: 100px;
        overflow-y: auto;

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
