import React from 'react'
import { Table } from 'antd'

const columns = [
  { title: 'ФИО', dataIndex: 'fio', key: 'fio' },
  { title: 'Должность', dataIndex: 'count', key: 'count' },
  { title: 'Статус', dataIndex: 'state', key: 'state' },
  {
    title: 'Action',
    dataIndex: '',
    key: 'x',
    render: () => <a>Удалить</a>,
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
  return <Table columns={columns} dataSource={data} />
}

export default TableComponents
