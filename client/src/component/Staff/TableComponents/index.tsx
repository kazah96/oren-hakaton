import React from 'react'
import { Table } from 'antd'

const TableComponents = (dataSource: any) => {
  const columns = [
    {
      title: 'Фамилия',
      dataIndex: 'surname',
    },
    {
      title: 'Имя',
      dataIndex: 'name',
    },
  ]
  const data = [dataSource.tableData]
  return <Table columns={columns} dataSource={data[0]} />
}

export default TableComponents
