<template>
  <div id="app">
    <router-view />
  </div>
</template>

<script>
export default {
  name: 'App',
  data: function () {
    return {
      auditStatusArray: [
        { text: '未标记', value: '0' },
        { text: '标记中', value: '1' },
        { text: '已标记', value: '2' },
        { text: '未审核', value: '3' },
        { text: '审核通过', value: '4' },
        { text: '审核不通过', value: '5' },
        { text: '跳过的文章', value: '6' },
        { text: '预处理的', value: '7' },
        { text: '无效的', value: '8' },
      ]
    }
  },
  created () {
    window.localStorage.setItem('articleStatusArray', JSON.stringify(this.auditStatusArray))
  }
}
</script>
