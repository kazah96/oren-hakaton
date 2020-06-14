import React from 'react'
import { Table } from 'antd'

const TableComponents = (dataSource: any) => {
  const columns = [
    {
      title: 'Адрес',
      dataIndex: 'address',
    },
    {
      title: 'Кол-во квартир',
      dataIndex: 'apartmentsCount',
    },
    {
      title: 'Состояние',
      dataIndex: 'state',
    },
  ]
  const data = [dataSource.tableData]
  return (
    <Table
      columns={columns}
      expandable={{
        expandedRowRender: (record: any) => {
          if (record.apartments.length > 0) {
            return <p style={{ margin: 0 }}>Квартиры</p>
          }
        },
      }}
      dataSource={data[0]}
    />
  )
}

export default TableComponents
