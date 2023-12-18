import React, { useState } from 'react';
import { useCallback } from 'react';
import { toggleDone } from '../../../utils/apiInteraction';

const QuestionDisplay = (props) => {
    const { selectedQuestion, onQuestionDataChange } = props
    const [done, setDone] = useState(selectedQuestion.done)
    const backgroundColour = done ?
        "bg-secondary" :
        "bg-primary"
    const doneBgColour = done ?
        "bg-success" :
        ""
    const classes = backgroundColour + " text-white p-3 rounded"

    const doneCheckboxOnChange = useCallback(e =>
        toggleDone(selectedQuestion.id, e.target.checked, (status, responseData) => {
            if (status === 200) {
                onQuestionDataChange()
                setDone(e.target.checked)
            } else {
                alert("Saving done result failed: " + status)
            }
        })
    )

    return (
        <div className={classes}>
            <div className={"mb-1 p-1 " + doneBgColour}>
                <label>Done</label>
                <input
                    type="checkbox"
                    defaultChecked={selectedQuestion.done}
                    onChange={doneCheckboxOnChange}
                    className="m-1"
                />
            </div>
            <div>
                <textarea readOnly className="w-100" value={selectedQuestion.questionText || ""}></textarea>
            </div>
            <div>
                <label>Solution</label>
                <textarea readOnly className="w-100" value={selectedQuestion.answerText || ""}></textarea>
            </div>
            <div>
                <label>Courses</label>
                <textarea readOnly className="w-100" value={selectedQuestion.course || ""}></textarea>
            </div>
            <div>
                <label>Tags</label>
                <textarea readOnly className="w-100" value={selectedQuestion.tags || ""}></textarea>
            </div>
        </div>
    )
}

export default QuestionDisplay