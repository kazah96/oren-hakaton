import React from 'react'
import { Table } from 'antd'

const TableComponents = (dataSource: any) => {
  const columns = [
    {
      title: 'Название',
      dataIndex: 'name',
    },
    {
      title: 'Ссылка на собрание',
      dataIndex: 'link',
    },
    {
      title: 'Адресс дома',
      dataIndex: 'house',
    },
    {
      title: 'Результат',
      dataIndex: 'result',
    },
  ]
  const data = [dataSource.tableData]
  return <Table columns={columns} dataSource={data[0]} />
}

export default TableComponents
