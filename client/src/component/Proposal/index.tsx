/* eslint-disable @typescript-eslint/no-use-before-define */
import React, { useState, useEffect } from 'react'

import TableComponents from './TableComponents'
import { useApi, ProposalApi } from '../../api'

const Proposal = () => {
  const [tableData, setTableData] = useState(false)

  useEffect(() => {
    getAllProposal().then((result: any) => {
      !tableData && setTableData(result.map((item: any) => ({ ...item, key: item.houseId })))
    })
    // eslint-disable-next-line
  }, [tableData])

  const { getAllProposal } = useApi({
    api: ProposalApi,
  }) as any

  return (
    <div>
      <TableComponents tableData={tableData} />
    </div>
  )
}

export default Proposal
