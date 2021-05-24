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
      <el-table-column prop="nickName" label="人员名称" sortable>
        <template slot-scope="scope">
          <input
            type="text"
            class="el-input__inner"
            placeholder="请输入内容1"
            :c-id="scope.row.id"
            :value="scope.row.nickName"
            @change="changeNickNameHandler"
          />
        </template>
      </el-table-column>
      <el-table-column label="操作">
        <template slot="header">
          <el-date-picker
            v-model="date"
            @change="dateChangeHandler"
            value-format="yyyy-MM-dd"
            type="daterange"
            align="right"
            unlink-panels
            range-separator="至"
            start-placeholder="开始日期"
            end-placeholder="结束日期"
          >
          </el-date-picker>
          <el-select
            v-model="auditstatusIndex"
            placeholder="全部"
            @change="changeStatusHandler"
          >
            <el-option
              v-for="item in auditStatusArray"
              :key="item.value"
              :label="item.text"
              :value="item.value"
            >
            </el-option>
          </el-select>
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
import { Loading } from 'element-ui'
import { Message } from 'element-ui';

export default {
  data () {
    return {
      date: [],
      startDate: null,
      endDate: null,
      data: [],
      pager: {
        index: 1,
        size: 100,
        total: 0
      },
      api: new UserCenterApi(ApiClient.instance),
      auditStatusArray: [
        { text: '全部', value: '-1' },
        { text: '未标记', value: '0' },
        { text: '标记中', value: '1' },
        { text: '已标记', value: '2' },
        { text: '未审核', value: '3' },
        { text: '审核通过', value: '4' },
        { text: '审核不通过', value: '5' },
        { text: '无效的', value: '6' },
      ],
      auditstatusIndex: null
    }
  },
  created () {
    this.searchWorkload()
  },
  computed: {
    formattedData () {
      return this.data
    },
    selectedStatus () {
      var status = parseInt(this.auditstatusIndex)

      if (status === null || isNaN(status) || status < 0) {
        return null
      }

      var selected = this.auditStatusArray.find(s => parseInt(s.value) === status)
      return parseInt(selected.value)
    }
  },
  methods: {
    changeNickNameHandler (e) {
      var element = e.target
      var id = element.getAttribute("c-id")
      var value = element.value

      var loadingInstance = Loading.service()
      this.api.apiUserCenterUserInfoPut({
        body: {
          id: id,
          nickName: value
        }
      }, (error, data, resp) => {
        loadingInstance.close()
        if (error) {
          Message.error({
            message: `ID:${id} 名称更新失败！`,
            duration: 0,
            showClose: true,
          })
          alert(error)
          console.error(error)
          return
        }

        if (data.success) {
          Message.success({
            message: `ID:${id} 名称更新成功！`,
            showClose: true,
          })
        } else {
          Message.error({
            message: `ID:${id} 名称更新失败！`,
            duration: 0,
            showClose: true,
          })
        }
      })
    },
    changeStatusHandler (params) {
      this.searchWorkload()
    },
    dateChangeHandler (params) {
      if (params) {
        this.startDate = params[0]
        this.endDate = params[1]
      } else {
        this.startDate = null
        this.endDate = null
      }

      this.searchWorkload()
    },
    searchWorkload () {
      this.api.apiUserCenterWorkloadPost({
        body: {
          startDate: this.startDate,
          endDate: this.endDate,
          articleStatus: this.selectedStatus,
          pageIndex: this.pager.index,
          pageSize: this.pager.size
        }
      }, (error, data, resp) => {
        if (error) {
          alert(error)
          return
        }

        if (data.success) {
          this.data = data.result.collection
          this.pager.index = 1
          this.pager.total = data.result.collection.length
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
 