import React, { useState } from 'react'
import { createQuestion } from '../utils/apiInteraction'

const CreateQuestion = () => {
    const [inputs, setInputs] = useState({});

    const handleChange = (event) => {
        const name = event.target.name;
        const value = event.target.value;
        setInputs(values => ({ ...values, [name]: value }))
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        createQuestion(inputs, (status, responseData) => {
            if (status === 200) {
                alert("Create question succeeded!")
            } else {
                alert("Create question failed! Status code = " + status)
            }
        })
    }

    return (
        <div class="row">
            <div class="col-md-4">
                <form onSubmit={handleSubmit}>
                    <div class="form-group">
                        <label class="control-label">Question Text</label>
                        <textarea name="question" class="form-control" onChange={handleChange} />
                    </div>
                    <div class="form-group">
                        <label class="control-label">Answer Text</label>
                        <textarea name="answer" class="form-control" onChange={handleChange} />
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Create" class="btn btn-primary" />
                    </div>
                </form>
            </div>
        </div>
    )
}

export default CreateQuestion
