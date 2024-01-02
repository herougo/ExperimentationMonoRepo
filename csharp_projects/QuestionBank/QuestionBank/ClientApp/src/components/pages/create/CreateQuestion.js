import React, { useState } from 'react'
import { createQuestion } from '../../../utils/apiInteraction'
import ListOfSelect from '../../reusable/ListOfSelect';

const CreateQuestion = () => {
    const [inputs, setInputs] = useState({});
    const [coursesOptions, setCoursesOptions] = useState([null, "Apple", "Book", "Cat"])
    const [tagsOptions, setTagsOptions] = useState([null, "Apple", "Book", "Cat"])

    const handleChange = (event) => {
        const name = event.target.name;
        const value = event.target.value;
        setInputs(values => ({ ...values, [name]: value }))
    }

    const coursesOnChange = (arr) => {
        setInputs(values => ({ ...values, courses: arr }))
    }

    const tagsOnChange = (arr) => {
        setInputs(values => ({ ...values, tags: arr }))
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
                        <label class="control-label">Courses</label>
                        <ListOfSelect options={coursesOptions} onChange={coursesOnChange} name="courses"></ListOfSelect>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Tags</label>
                        <ListOfSelect options={tagsOptions} onChange={tagsOnChange} name="courses"></ListOfSelect>
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Create" class="btn btn-primary mt-2" />
                    </div>
                </form>
            </div>
        </div>
    )
}

export default CreateQuestion
