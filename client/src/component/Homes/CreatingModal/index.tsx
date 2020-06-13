import React, { useState } from 'react'
import { Modal } from 'antd'

import Form from './Form'

// @ts-ignore
const CreatingModal = ({ visible, onCancel, onSubmitForm, defaultFormData, okText }) => {
  const onSubmit = (data: any) => {
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
        <Form formData={defaultFormData} />
      </div>
    </Modal>
  )
}

export default CreatingModal
