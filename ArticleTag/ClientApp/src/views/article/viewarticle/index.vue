<template>
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
          @click="scrollToView"
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
    </div>
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
      tags: [],
      articleId: '',
      review: false,
      article: ''
    }
  },
  created () {
    this.articleId = this.$route.params.id
    this.searchArticle().then((resp) => {
      this.bindTooltip()
    })
  },
  methods: {
    scrollToView (e) {
      // 滚动到固定元素
      var id = e.target.getAttribute('c-id')
      document.querySelector(`#mark-id-${id}`).scrollIntoView();
    },
    searchArticle () {
      var p = new Promise((resolve, reject) => {
        // 调用API查询 文章和标记
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

    @footheight: 300px;
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
        height: 200px;
        border-bottom: 1px solid rgba(0, 0, 0, 0.1);

        .tags {
          margin: 5px;
        }
      }

      .check-box {
        padding: 0.5rem 0;
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
