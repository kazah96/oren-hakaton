import React, { useState } from 'react'
import { Button, message } from 'antd'

import CreatingModal from './CreatingModal'

const defaultModalSettings = {
  visible: false,
  defaultFormData: null,
  okText: 'Добавить',
}

const Homes = () => {
  const [creactingModalSettings, setCreactingModalSettings] = useState(defaultModalSettings)

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
    message.success('Вход выполнен')
  }

  const handleSubmitCreatingForm = (formData: any) => {
    createItem(formData)
    handleCancelCreatingModal()
  }

  return (
    <div>
      <Button type="primary" onClick={handleAddItemClick}>
        Добавить дом
      </Button>
      <CreatingModal
        visible={creactingModalSettings.visible}
        defaultFormData={creactingModalSettings.defaultFormData}
        okText={creactingModalSettings.okText}
        onCancel={handleCancelCreatingModal}
        onSubmitForm={handleSubmitCreatingForm}
      />
    </div>
  )
}

export default Homes
