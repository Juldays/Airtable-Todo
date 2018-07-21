import * as axios from "axios";

export function todoRecord_create(data) {
    return axios.post("api/airtable", data);
}