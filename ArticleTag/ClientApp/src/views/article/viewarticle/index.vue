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
      height: 220px;
      width: 100%;
      bottom: 0px;
      // box-shadow: 0 2px 4px rgba(0, 0, 0, 0.12), 0 0 6px rgba(0, 0, 0, 0.04);
      box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
      background-color: #fff;

      .mark-history {
        height: 220px;
        // border-bottom: 1px solid rgba(0, 0, 0, 0.1);
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
