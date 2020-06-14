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
        <div className="label">Ссылка на транслящию</div>
        <div className="fieldContainer">
          <Input
            name="link"
            size="large"
            defaultValue={formData.link}
            onChange={createTextFieldChangeHandler('link')}
          />
        </div>
      </div>
      <div className="section">
        <div className="label">Дом</div>
        <div className="fieldContainer">
          <Input
            name="house"
            size="large"
            defaultValue={formData.house}
            onChange={createTextFieldChangeHandler('house')}
          />
        </div>
      </div>
      <div className="section">
        <div className="label">Результат</div>
        <div className="fieldContainer">
          <Input
            name="result"
            size="large"
            defaultValue={formData.result}
            onChange={createTextFieldChangeHandler('result')}
          />
        </div>
      </div>
    </div>
  )
}

export default CreatingForm
