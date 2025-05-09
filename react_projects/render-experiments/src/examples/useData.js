import React, { useCallback, useMemo, useState } from 'react';

const useData = () => {
    const [count, setCount] = useState(0);
    const [error, setError] = useState(0);

    const dependencies = [count, error];

    const onClick = useCallback(() => {
        setCount((count) => count+1)
    }, []);

    return {
        count,
        error,
        onClick
    };
};

export default useData;
