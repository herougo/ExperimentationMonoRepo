import React, { useEffect, useState } from 'react';
import QuestionsTable from './QuestionsTable';
import getFilteredQuestions from '../utils/apiInteraction'
import useDataLoad from '../hooks/useDataLoad';

const QuestionsPage = () => {
    const [tableData, onChange] = useDataLoad(getFilteredQuestions)

    const contents = tableData === null ?
        "Loading..." :
        <QuestionsTable questions={tableData} />

    return (
        <div>
            <h1>Questions</h1>
            {contents}
        </div>
    );
}

export default QuestionsPage