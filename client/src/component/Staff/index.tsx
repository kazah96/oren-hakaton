/* eslint-disable @typescript-eslint/no-use-before-define */
import React, { useState, useEffect } from 'react'
import { Button, message } from 'antd'

import CreatingModal from './CreatingModal'
import TableComponents from './TableComponents'
import { useApi, StaffApi } from '../../api'

const defaultModalSettings = {
  visible: false,
  defaultFormData: null,
  okText: 'Добавить',
}

const Staff = () => {
  const [creactingModalSettings, setCreactingModalSettings] = useState(defaultModalSettings)
  const [tableData, setTableData] = useState(false)

  useEffect(() => {
    getAllStaff().then((result: any) => {
      !tableData && setTableData(result.map((item: any) => ({ ...item, key: item.houseId })))
    })
    // eslint-disable-next-line
  }, [tableData])

  const { saveStaff, getAllStaff } = useApi({
    api: StaffApi,
  }) as any

  const changeCreatingModalSettings = (payload: any) => {
    setCreactingModalSettings({ ...creactingModalSettings, ...payload })
  }

  const handleShowCreatingModal = () => {
    changeCreatingModalSettings({ visible: true })
  }

  const handleCancelCreatingModal = () => {
    changeCreatingModalSettings(defaultModalSettings)
  }

  const handleAddItemClick = () => {
    handleShowCreatingModal()
  }

  const createItem = (formData: any) => {
    saveStaff(formData).then(() => message.success('Вход выполнен'))
  }

  const handleSubmitCreatingForm = (formData: any) => {
    createItem(formData)
    handleCancelCreatingModal()
  }

  return (
    <div>
      <Button type="primary" onClick={handleAddItemClick}>
        Добавить рабочего
      </Button>
      <CreatingModal
        visible={creactingModalSettings.visible}
        defaultFormData={creactingModalSettings.defaultFormData}
        okText={creactingModalSettings.okText}
        onCancel={handleCancelCreatingModal}
        onSubmitForm={handleSubmitCreatingForm}
      />
      <TableComponents tableData={tableData} />
    </div>
  )
}

export default Staff
