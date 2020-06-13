import React from 'react'
import { Input } from 'antd'
import './style.css'

// @ts-ignore
const CreatingForm = ({ formData, onChangeForm }) => {
  const createTextFieldChangeHandler = (param: any) => (e: { target: { value: any } }) => {
    const { value } = e.target
    onChangeForm({ [param]: value })
  }

  return (
    <div className="form">
      <div className="section">
        <div className="label">Адрес</div>
        <div className="fieldContainer">
          <Input
            name="Address"
            size="large"
            defaultValue={formData.Address}
            onChange={createTextFieldChangeHandler('Address')}
          />
        </div>
      </div>
      <div className="section">
        <div className="label">Кол-во квартир</div>
        <div className="fieldContainer">
          <Input
            name="apartmentsCount"
            size="large"
            defaultValue={formData.apartmentsCount}
            onChange={createTextFieldChangeHandler('apartmentsCount')}
          />
        </div>
      </div>
      <div className="section">
        <div className="label">Стостояние</div>
        <div className="fieldContainer">
          <Input
            name="State"
            size="large"
            defaultValue={formData.State}
            onChange={createTextFieldChangeHandler('State')}
          />
        </div>
      </div>
    </div>
  )
}

export default CreatingForm
