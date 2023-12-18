import React from 'react';

const QuestionDisplay = (props) => {
    const { selectedQuestion } = props
    const backgroundColour = selectedQuestion.done ?
        "bg-secondary" :
        "bg-primary"
    const classes = backgroundColour + " text-white p-3 rounded"

    return (
        <div className={classes}>
            {
                selectedQuestion.done ?
                    <div className="rounded p-1 text-center bg-success">Done</div> :
                    null
            }
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