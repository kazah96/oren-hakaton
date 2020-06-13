import RestApi from './rest-api'
class UserApi extends RestApi {
  CheckUser = (data) => {
    return this.postRestRequest({
      url: 'api/Entities/get/Authorization',
      data: data.user,
    }).then((result) => {
      return Promise.resolve(result)
    })
  }

  saveUser = (data) => {
    return this.postRestRequest({
      url: 'api/Entities/Add/Authorization',
      data: data.user,
    }).then((result) => {
      return Promise.resolve(result)
    })
  }
}

export default UserApi
