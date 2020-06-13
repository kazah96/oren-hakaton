import React from 'react'
import { Input } from 'antd'
import './style.css'

const CreatingForm = (formData: any) => {
  return (
    <div className="form">
      <div className="section">
        <div className="label">Адрес</div>
        <div className="fieldContainer">
          <Input name="Address" size="large" defaultValue={formData.Address} />
        </div>
      </div>
      <div className="section">
        <div className="label">Кол-во квартир</div>
        <div className="fieldContainer">
          <Input name="AparmentsCount" size="large" defaultValue={formData.AparmentsCount} />
        </div>
      </div>
      <div className="section">
        <div className="label">Стостояние</div>
        <div className="fieldContainer">
          <Input name="State" size="large" defaultValue={formData.State} />
        </div>
      </div>
    </div>
  )
}

export default CreatingForm
