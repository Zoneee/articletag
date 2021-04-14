<template>
  <div class="container">
    <el-table
      :data="formattedData"
      style="width: 100%"
      row-key="id"
      empty-text="暂无"
      :tree-props="{ children: 'children', hasChildren: 'hasChildren' }"
    >
      <el-table-column prop="id" label="文章ID" sortable> </el-table-column>
      <el-table-column prop="taskID" label="任务ID" sortable> </el-table-column>
      <el-table-column prop="lastTimeStr" label="最后标注时间" sortable>
      </el-table-column>
      <el-table-column label="标记者">
        <template slot-scope="scope">
          <el-popover trigger="hover" placement="left-start">
            <p>UID: {{ scope.row.tagger.id }}</p>
            <p>姓名: {{ scope.row.tagger.name }}</p>
            <p>邮箱: {{ scope.row.tagger.email }}</p>
            <div slot="reference" class="name-wrapper">
              <el-tag size="medium">{{ scope.row.tagger.name }}</el-tag>
            </div>
          </el-popover>
        </template>
      </el-table-column>
      <el-table-column label="文章状态">
        <template slot-scope="scope">
          <el-tag size="medium" :type="statusStyle(scope.row)">{{
            scope.row.statusRemark
          }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="AuditRemark" label="审核备注">
        <template slot-scope="scope">
          <el-popover trigger="hover" placement="left-start">
            <div v-for="record in scope.row.auditRecords" :key="record.id">
              <p>></p>
              <p>审核ID: {{ record.id }}</p>
              <p>审核时间: {{ record.recordTimeStr }}</p>
              <p>审核内容: {{ record.remark }}</p>
            </div>
            <div slot="reference" class="name-wrapper">
              <el-tag size="medium">审核记录</el-tag>
            </div>
          </el-popover>
        </template>
      </el-table-column>
      <el-table-column label="审核者">
        <template slot-scope="scope">
          <el-popover trigger="hover" placement="left-start">
            <p>UID: {{ scope.row.auditor.id }}</p>
            <p>姓名: {{ scope.row.auditor.name }}</p>
            <div slot="reference" class="name-wrapper">
              <el-tag size="medium">{{ scope.row.auditor.name }}</el-tag>
            </div>
          </el-popover>
        </template>
      </el-table-column>
      <el-table-column label="操作">
        <!-- 服务端搜索 -->
        <template slot="header" slot-scope="scope">
          <el-input
            v-model="taggerName"
            size="mini"
            placeholder="输入标记者姓名搜索"
            @change="searchByTaggerName"
          />
        </template>
        <template slot-scope="scope">
          <el-button size="mini" @click="handleView(scope.$index, scope.row)"
            >查看</el-button
          >
          <el-button
            size="mini"
            @click="handleAudit(scope.$index, scope.row)"
            type="danger"
            v-if="role === 1"
            >审核</el-button
          >
        </template>
      </el-table-column>
    </el-table>
    <el-pagination
      id="pagination"
      @size-change="handleSizeChange"
      @current-change="handleCurrentChange"
      :current-page="pager.index"
      :page-sizes="[100, 200, 300, 400]"
      :page-size="pager.size"
      layout="total, sizes, prev, pager, next, jumper"
      :total="pager.total"
    >
    </el-pagination>
  </div>
</template>

<script>
import { ApiClient, ArticleApi, TagArticleStatusEnum, TagRoleEnum } from '@/api'

export default {
  data () {
    return {
      api: new ArticleApi(ApiClient.instance),
      auditStatusEnum: new TagArticleStatusEnum(),
      taggerName: '',
      pager: {
        index: 1,
        size: 100,
        total: 0
      },
      data: [],
      roleEnum: new TagRoleEnum(),
      role: 0
    }
  },
  created () {
    this.searchTableData()
    var userInfo = JSON.parse(window.localStorage.getItem('user_info') || '{}')
    this.role = userInfo.role
  },
  computed: {
    formattedData () {
      for (var t of this.data) {
        t.lastTimeStr = this.formatDate(t.lastChangeTime)
        if (t.auditRecords) {
          for (var a of t.auditRecords) {
            a.recordTimeStr = this.formatDate(a.recordTime)
          }
        }
      }
      console.log(this.data)
      return this.data
    }
  },
  methods: {
    formatDate (date) {
      var y = date.getFullYear()
      var m = date.getMonth() + 1
      var d = date.getDate()

      var result = `${y}-${m}-${d}`
      if (result === '1-1-1' || result === '1970-1-1') {
        return ''
      }
      return `${y}-${m}-${d}`
    },
    handleView (index, row) {
      this.$router.push({
        path: `/article/viewarticle/${row.id}`
      })
      console.log(index, row);
    },
    handleAudit (index, row) {
      this.$router.push({
        path: `/article/auditarticle/${row.id}`
      })
      console.log(index, row);
    },
    searchTableData () {
      // 翻页查询
      console.log('翻页查询')

      this.api.apiArticlePagingAritclePost({
        page: this.pager.index,
        size: this.pager.size
      }, (error, data, resp) => {
        if (error) {
          alert(error)
          return
        }

        if (data.success) {
          this.data = data.result.records
          this.pager.total = data.result.total
        }
      })

    },
    searchByTaggerName (value) {
      // 根据标记者名称查询
      this.pager.index = 1
      this.api.apiArticleSearchArticleByTaggerPost({
        tagger: value,
        page: this.pager.index,
        size: this.pager.size
      }, (error, data, resp) => {
        if (error) {
          alert(error)
          return
        }

        if (data.success) {
          this.data = data.result.records
          this.pager.total = data.result.total
        }
      })
    },
    handleSizeChange (size) {
      this.pager.index = 1
      this.pager.size = size
      this.searchTableData()
    },
    handleCurrentChange (index) {
      this.pager.index = index
      this.searchTableData()
    },
    statusStyle (row) {
      switch (row.status) {
        case this.auditStatusEnum.Audited:
          return 'success'
        case this.auditStatusEnum.Unaudited:
          return 'primary'
        case this.auditStatusEnum.Unsanctioned:
          return 'danger'
        default:
          return 'info'
      }
    }
  }
}
</script>

<style lang="less" scoped>
  .container {
    position: relative;
    display: contents;
    #pagination {
      position: absolute;
      bottom: 0px;
      width: 100%;
      border-top: 1px solid rgba(0, 0, 0, 0.1);
      padding: 5px;
      position: fixed;
      background: white;
    }
    .el-table {
      padding-bottom: 39px;
    }
  }
</style>
 