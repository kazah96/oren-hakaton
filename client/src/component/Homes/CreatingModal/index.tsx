import React from 'react'
import { Modal } from 'antd'

import Form from './Form'

const defaultForm = {
  Address: '',
  AparmentsCount: null,
  State: null,
}

// @ts-ignore
const CreatingModal = ({ visible, onCancel, onSubmitForm, defaultFormData, okText }) => {
  const onSubmit = (data: any) => {
    debugger
    onSubmitForm(data)
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
        <Form formData={defaultFormData || defaultForm} />
      </div>
    </Modal>
  )
}

export default CreatingModal
