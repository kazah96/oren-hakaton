import React, { useState } from 'react'
import { Modal } from 'antd'

import Form from './Form'

const defaultForm = {
  name: '',
  link: '',
  result: '',
  house: '',
}

// @ts-ignore
const CreatingModal = ({ visible, onCancel, onSubmitForm, defaultFormData, okText }) => {
  const [formData, setFormData] = useState(defaultFormData || defaultForm)

  const handleFormChange = (payload: any) => {
    setFormData({ ...formData, ...payload })
  }

  const onSubmit = () => {
    onSubmitForm(formData)
  }

  return (
    <Modal
      visible={visible}
      onCancel={onCancel}
      okText={okText}
      bodyStyle={{ padding: 0 }}
      width={560}
      onOk={onSubmit}
      closable={false}
      destroyOnClose
    >
      <div className="create_modal">
        <Form formData={defaultFormData || defaultForm} onChangeForm={handleFormChange} />
      </div>
    </Modal>
  )
}

export default CreatingModal
