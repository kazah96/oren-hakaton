/* eslint-disable @typescript-eslint/no-use-before-define */
import React, { useState, useEffect } from 'react'
import { Button, message } from 'antd'

import CreatingModal from './CreatingModal'
import TableComponents from './TableComponents'
import { useApi, MeetingsApi } from '../../api'

const defaultModalSettings = {
  visible: false,
  defaultFormData: null,
  okText: 'Добавить',
}

const Metting = () => {
  const [creactingModalSettings, setCreactingModalSettings] = useState(defaultModalSettings)
  const [tableData, setTableData] = useState(false)

  useEffect(() => {
    getAllMeetings().then((result: any) => {
      !tableData && setTableData(result.map((item: any) => ({ ...item, key: item.houseId })))
    })
    // eslint-disable-next-line
  }, [tableData])

  const { saveMeeting, getAllMeetings } = useApi({
    api: MeetingsApi,
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
    saveMeeting(formData).then(() => message.success('Запрос на встречу отправлен'))
  }

  const handleSubmitCreatingForm = (formData: any) => {
    createItem(formData)
    handleCancelCreatingModal()
  }

  return (
    <div>
      <Button type="primary" onClick={handleAddItemClick}>
        Добавить встречу
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

export default Metting
