import React from 'react'
import { Table } from 'antd'

const columns = [
  { title: 'Адрес дома', dataIndex: 'address', key: 'adress' },
  { title: 'Колличество квартир', dataIndex: 'count', key: 'count' },
  { title: 'Состояние', dataIndex: 'state', key: 'state' },
  {
    title: 'Action',
    dataIndex: '',
    key: 'x',
    render: () => <p>Удалить</p>,
  },
]

const data = [
  {
    key: 1,
    address: 'Чкалова 32',
    count: 32,
    state: 'вялое',
    description: 'Квартиры',
  },
  {
    key: 2,
    address: 'Чкалова 37',
    count: 42,
    state: 'хорошее',
    description: 'Квартиры ',
  },
]

const TableComponents = () => {
  return (
    <Table
      columns={columns}
      expandable={{
        expandedRowRender: (record) => <p style={{ margin: 0 }}>{record.description}</p>,
      }}
      dataSource={data}
    />
  )
}

export default TableComponents
