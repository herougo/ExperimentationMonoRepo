import authService from "../components/api-authorization/AuthorizeService";


async function authorizedGetFetch(fetchUrl) {
    const token = await authService.getAccessToken();
    const response = await fetch(fetchUrl, {
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const data = await response.json();
    return [response.status, data]
}

async function authorizedPostFetch(fetchUrl, body) {
    const token = await authService.getAccessToken()
    let headers = !token ? {} : { 'Authorization': `Bearer ${token}` }
    headers = {
        ...headers,
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }
    const response = await fetch(fetchUrl, {
        headers: headers,
        method: "POST",
        body: JSON.stringify(body)
    });
    let responseData = {}
    if (response.status === 200) {
        try {
            responseData = await response.json();
        } catch { }
    }
    return [response.status, responseData]
}

async function getFilteredQuestions(callback) {
    const [status, data] = await authorizedGetFetch('questions/filtered')
    callback(data)
}

async function createQuestion(data, callback) {
    const payload = {
        "QuestionText": data.question || "",
        "AnswerText": data.answer || ""
    }
    const [status, responseData] = await authorizedPostFetch('questions/create', payload)
    callback(status, responseData)
}

async function createTag(data, callback) {
    const payload = {
        "Name": data.name || "",
        "Description": data.description || ""
    }
    const [status, responseData] = await authorizedPostFetch('tags/create', payload)
    callback(status, responseData)
}

async function createCourse(data, callback) {
    const payload = {
        "Code": data.code || "",
        "Title": data.title || ""
    }
    const [status, responseData] = await authorizedPostFetch('courses/create', payload)
    callback(status, responseData)
}

export {
    getFilteredQuestions,
    createQuestion,
    createTag,
    createCourse
}