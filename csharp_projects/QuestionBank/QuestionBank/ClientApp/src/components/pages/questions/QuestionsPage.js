import React, { useState } from 'react';
import QuestionsTable from './QuestionsTable';
import { getFilteredQuestions } from '../../../utils/apiInteraction'
import useDataLoad from '../../../hooks/useDataLoad';
import QuestionDisplay from './QuestionDisplay';

const QuestionsPage = () => {
    const [tableData, onChange] = useDataLoad(getFilteredQuestions)
    const [selectedQuestion, setSelectedQuestion] = useState(null)

    const contents = tableData === null ?
        "Loading..." :
        <QuestionsTable questions={tableData} setSelectedQuestion={setSelectedQuestion} />

    const questionDisplay = selectedQuestion === null ?
        null :
        <div class="col">
            <QuestionDisplay selectedQuestion={selectedQuestion} onQuestionDataChange={onChange} />
        </div>

    return (
        <div>
            <h1>Questions</h1>
            <button class="btn btn-primary m-1">Generate Sample Exam</button><br/>
            <button class="btn btn-primary m-1">Export Questions to PDF</button><br />
            <div class="row">
                <div class="col">
                    {contents}
                </div>
                {questionDisplay}
            </div>
        </div>
    );
}

export default QuestionsPage