import { WebApi } from "../../../web-api";

export const GetAlarms = async (dispatch) => {
    const WebAPIs = new WebApi();
    await dispatch(WebAPIs.GetAlarms());
}

