import React, { useState } from 'react';
import QuestionsTable from './QuestionsTable';
import { getFilteredQuestions } from '../../../utils/apiInteraction'
import useDataLoad from '../../../hooks/useDataLoad';
import QuestionDisplay from './QuestionDisplay';

const QuestionsPage = () => {
    const [tableData, onChange] = useDataLoad(getFilteredQuestions)
    // const [selectedQuestion, setSelectedQuestion] = useState(null)
    const selectedQuestion = tableData === null ? null : tableData[tableData.length - 1]

    const contents = tableData === null ?
        "Loading..." :
        <QuestionsTable questions={tableData} />

    const questionDisplay = selectedQuestion === null ?
        null :
        <div class="col">
            <QuestionDisplay selectedQuestion={selectedQuestion} />
        </div>

    return (
        <div>
            <h1>Questions</h1>
            <button class="btn btn-primary">Generate Sample Exam</button><br/>
            <button class="btn btn-primary">Export Questions to PDF</button><br />
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