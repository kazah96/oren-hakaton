import React from 'react'
import { Input } from 'antd'
import './style.css'

const CreatingForm = (formData: any) => {
  return (
    <div className="form">
      <div className="section">
        <div className="label">Адрес</div>
        <div className="fieldContainer">
          <Input name="adress" size="large" defaultValue={formData.adress} />
        </div>
      </div>
      <div className="section">
        <div className="label">Кол-во квартир</div>
        <div className="fieldContainer">
          <Input name="count" size="large" defaultValue={formData.count} />
        </div>
      </div>
      <div className="section">
        <div className="label">Стостояние</div>
        <div className="fieldContainer">
          <Input name="state" size="large" defaultValue={formData.state} />
        </div>
      </div>
    </div>
  )
}

export default CreatingForm
