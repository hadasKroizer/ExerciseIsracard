import React, { useEffect, useState } from 'react';

function Operator({ children }) {
    return (
        <span>{["", "+", "-", "*", "/"][children]}</span>
    );
}

export default Operator;
