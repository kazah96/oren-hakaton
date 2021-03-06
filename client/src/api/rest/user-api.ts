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
      url: 'api/Entities/get/managecomp',
      data: data.user,
    }).then((result) => {
      return Promise.resolve(result)
    })
  }

  saveUser = (data: Data) => {
    return this.postRestRequest({
      url: 'api/Entities/Add/managecomp',
      data: data.user,
    }).then((result) => {
      return Promise.resolve(result)
    })
  }
}

export default UserApi
