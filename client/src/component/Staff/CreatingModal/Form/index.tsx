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
        <div className="label">Фамилия</div>
        <div className="fieldContainer">
          <Input
            name="surname"
            size="large"
            defaultValue={formData.surname}
            onChange={createTextFieldChangeHandler('surname')}
          />
        </div>
      </div>
      <div className="section">
        <div className="label">Имя</div>
        <div className="fieldContainer">
          <Input
            name="name"
            size="large"
            defaultValue={formData.name}
            onChange={createTextFieldChangeHandler('name')}
          />
        </div>
      </div>
      <div className="section">
        <div className="label">Специальность</div>
        <div className="fieldContainer">
          <Input
            name="specialties"
            size="large"
            defaultValue={formData.specialties}
            onChange={createTextFieldChangeHandler('specialties')}
          />
        </div>
      </div>
    </div>
  )
}

export default CreatingForm
