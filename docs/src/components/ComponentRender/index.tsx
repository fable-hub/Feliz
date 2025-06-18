import ErrorBoundary from '@docusaurus/ErrorBoundary';
import React, { ReactNode, useState } from 'react';
import styles from './styles.module.css';
import CodeBlock from '@theme/CodeBlock';

interface ComponentRenderProps {
  children: ReactNode;
  code: string;
  language?: string;
}

export default function ComponentRender({ children, code, language = "fsharp" }: ComponentRenderProps) {

  const [instanceKey, setInstanceKey] = useState(0);

  const handleRestart = () => setInstanceKey(prev => prev + 1);

  return (
    <div className={styles.previewWrapper}>
      <div className={styles.previewBlock}>
        <ErrorBoundary
            key={instanceKey}
            fallback={({error, tryAgain}) => (
              <div>
                <p>This component crashed because of error: {error.message}.</p>
                <button onClick={tryAgain}>Try Again!</button>
              </div>
            )}>
            <button className={styles.rerenderButton} onClick={handleRestart}>
              <svg xmlns="http://www.w3.org/2000/svg" width={24} height={24} viewBox="0 0 24 24">
	<path fill="currentColor" d="M21.074 12.154a.75.75 0 0 1 .672.82c-.49 4.93-4.658 8.776-9.724 8.776c-2.724 0-5.364-.933-7.238-2.68L3 20.85a.75.75 0 0 1-.75-.75v-3.96c0-.714.58-1.29 1.291-1.29h3.97a.75.75 0 0 1 .75.75l-2.413 2.407c1.558 1.433 3.78 2.243 6.174 2.243c4.29 0 7.817-3.258 8.232-7.424a.75.75 0 0 1 .82-.672m-18.82-1.128c.49-4.93 4.658-8.776 9.724-8.776c2.724 0 5.364.933 7.238 2.68L21 3.15a.75.75 0 0 1 .75.75v3.96c0 .714-.58 1.29-1.291 1.29h-3.97a.75.75 0 0 1-.75-.75l2.413-2.408c-1.558-1.432-3.78-2.242-6.174-2.242c-4.29 0-7.817 3.258-8.232 7.424a.75.75 0 1 1-1.492-.148"></path>
</svg>
            </button>
            {children}
        </ErrorBoundary>
      </div>
      <CodeBlock language={language} showLineNumbers>
          {code}
      </CodeBlock>
    </div>
  );
}
