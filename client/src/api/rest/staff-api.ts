import RestApi from './rest-api'

interface Data {
  user: {
    name: string
  }
}
class StaffApi extends RestApi {
  constructor(requestUrl?: string) {
    super(requestUrl || '')
  }

  getAllStaff = () => {
    return this.getRestRequest({
      url: 'api/Entities/GetAll/Employes',
    }).then((result) => {
      return Promise.resolve(result)
    })
  }

  saveStaff = (data: Data) => {
    return this.postRestRequest({
      url: 'api/Entities/Add/Employes',
      data,
    }).then((result) => {
      return Promise.resolve(result)
    })
  }
}

export default StaffApi
