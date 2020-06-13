import RestApi from './rest-api'

interface Data {
  user: {
    name: string
  }
}
class UserApi extends RestApi {
  constructor(requestUrl?: string) {
    super(requestUrl || '')
  }

  CheckUser = (data: Data) => {
    return this.postRestRequest({
      url: 'api/Entities/Get/Authorization',
      data: data.user,
    }).then((result) => {
      return Promise.resolve(result.content)
    })
  }

  saveUser = (data: Data) => {
    return this.postRestRequest({
      url: 'api/Entities/Add/Authorization',
      data: data.user,
    }).then((result) => {
      return Promise.resolve(result.content)
    })
  }
}

export default UserApi
