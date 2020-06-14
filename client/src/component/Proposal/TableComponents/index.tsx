import React from 'react'
import { Table } from 'antd'

const TableComponents = (dataSource: any) => {
  const columns = [
    {
      title: 'Название',
      dataIndex: 'name',
    },
    {
      title: 'Адрес',
      dataIndex: 'address',
    },
    {
      title: 'Статус',
      dataIndex: 'status',
    },
    {
      title: 'Проблема',
      dataIndex: 'note',
    },
  ]
  const data = [dataSource.tableData]
  return <Table columns={columns} dataSource={data[0]} />
}

export default TableComponents
