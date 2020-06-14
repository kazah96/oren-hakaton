import RestApi from './rest-api'

interface Data {
  user: {
    address: string
  }
}
class ProposalApi extends RestApi {
  constructor(requestUrl?: string) {
    super(requestUrl || '')
  }

  getAllProposal = () => {
    return this.getRestRequest({
      url: 'api/Entities/GetAll/Requests',
    }).then((result) => {
      return Promise.resolve(result)
    })
  }

  saveProposal = (data: Data) => {
    return this.postRestRequest({
      url: 'api/Entities/Add/Meetings',
      data,
    }).then((result) => {
      return Promise.resolve(result)
    })
  }
}

export default ProposalApi
