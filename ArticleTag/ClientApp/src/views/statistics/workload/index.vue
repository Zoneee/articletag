<template>
  <div class="container">
    <el-table
      :data="formattedData"
      style="width: 100%"
      row-key="id"
      empty-text="暂无"
      :tree-props="{ children: 'children', hasChildren: 'hasChildren' }"
    >
      <el-table-column prop="id" label="人员ID"> </el-table-column>
      <el-table-column prop="email" label="标记员帐号"> </el-table-column>
      <el-table-column prop="count" label="标记数量" sortable>
      </el-table-column>
      <el-table-column label="操作">
        <template slot="header" slot-scope="scope">
          <el-date-picker
            v-model="date"
            @change="dateChangeHandler"
            type="date"
            value-format="yyyy-MM-dd"
            placeholder="选择日期"
          >
          </el-date-picker>
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
import { ApiClient, UserCenterApi } from '@/api'

export default {
  data () {
    return {
      date: '',
      data: [],
      pager: {
        index: 1,
        size: 100,
        total: 0
      },
      api: new UserCenterApi(ApiClient.instance)
    }
  },
  created () {
    const date = new Date();
    date.setTime(date.getTime() - 3600 * 1000 * 24);
    this.date = date

    this.searchWorkload()
  },
  computed: {
    formattedData () {
      return this.data
    }
  },
  methods: {
    dateChangeHandler (date) {
      this.date = date
      this.searchWorkload()
    },
    searchWorkload () {
      console.log(this.date)
      this.api.apiUserCenterWorkloadPost({
        _date: this.date
      }, (error, data, resp) => {
        if (error) {
          alert(error)
          return
        }
        if (data.success) {
          this.data = data.result.collection
        }
      })
    },
    handleSizeChange (size) {
      this.pager.index = 1
      this.pager.size = size
      this.searchWorkload()
    },
    handleCurrentChange (index) {
      this.pager.index = index
      this.searchWorkload()
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
 