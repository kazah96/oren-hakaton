import React from 'react'

import { Form, Input, Button, message } from 'antd'
import { useApi, UserApi } from '../../api'

const layout = {
  labelCol: { span: 10 },
  wrapperCol: { span: 5 },
}

/* eslint-disable */
const validateMessages = {
  // eslint-ignore
  required: '${label} обязательное поле!',
  types: {
    // eslint-ignore
    email: '${label} не правильный формат!',
  },
}
/* eslint-enable */

const Login = () => {
  const { CheckUser } = useApi({
    api: UserApi,
  }) as any

  const onFinish = (data: any) => {
    CheckUser(data).then(() => message.success('Вход выполнен'))
  }

  return (
    <Form {...layout} onFinish={onFinish} name="login-form" validateMessages={validateMessages}>
      <Form.Item name={['user', 'Mail']} label="Email" rules={[{ required: true, type: 'email' }]}>
        <Input />
      </Form.Item>
      <Form.Item name={['user', 'Password']} label="Password" rules={[{ required: true }]}>
        <Input />
      </Form.Item>
      <Form.Item wrapperCol={{ ...layout.wrapperCol, offset: 10 }}>
        <Button type="primary" htmlType="submit">
          Отправить
        </Button>
      </Form.Item>
    </Form>
  )
}

export default Login
