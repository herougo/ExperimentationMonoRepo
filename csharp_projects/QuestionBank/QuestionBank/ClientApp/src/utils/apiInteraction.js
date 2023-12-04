import authService from "../components/api-authorization/AuthorizeService";


async function authorizedFetch(fetchUrl) {
    const token = await authService.getAccessToken();
    const response = await fetch(fetchUrl, {
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const data = await response.json();
    return data
}

async function getFilteredQuestions(callback) {
    const data = await authorizedFetch('questions/filtered')
    callback(data)
}

export default getFilteredQuestions