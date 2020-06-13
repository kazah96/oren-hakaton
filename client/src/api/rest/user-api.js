import RestApi from './rest-api'
class UserApi extends RestApi {
  CheckUser = (data) => {
    return this.postRestRequest({
      url: 'api/Entities/Get/Authorization',
      data: data.user,
    }).then((result) => {
      return Promise.resolve(result.content)
    })
  }

  saveUser = (data) => {
    return this.postRestRequest({
      url: 'api/Entities/Add/Authorization',
      data: data.user,
    }).then((result) => {
      return Promise.resolve(result.content)
    })
  }
}

export default UserApi
