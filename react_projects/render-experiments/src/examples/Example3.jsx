import React, { useCallback, useMemo, useState } from 'react';
import CounterButton from './CounterButton';
import CounterText from './CounterText';
import CounterFooter from './CounterFooter';
import useData from './useData';

const CounterButtonMemo = React.memo(CounterButton);
const CounterTextMemo = React.memo(CounterText);
const CounterFooterMemo = React.memo(CounterFooter);

const Counter = () => {
    console.log('Counter render');
    const myData = useData();

    return (
        <div>
            <CounterTextMemo count={myData.count} />
            <CounterButtonMemo onClick={myData.onClick} />
            <CounterFooterMemo />
        </div>
    );
};

const Example3 = () => {
    console.log('Example3 render');
    return (
        <Counter>
            
        </Counter>
    );
}

export default Example3;
