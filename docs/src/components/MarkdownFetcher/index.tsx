import React, { ReactNode, useEffect, useState, Suspense } from 'react';
import Markdown from 'react-markdown'
import remarkGfm from 'remark-gfm'
import remarkDirective from 'remark-directive';
import rehypeRaw from 'rehype-raw';
import rehypeHighlight from 'rehype-highlight';
import styles from './styles.module.css';
import {common} from 'lowlight'
import fsharp from 'highlight.js/lib/languages/fsharp'
import {useColorMode} from '@docusaurus/theme-common';
import lightStyles from '!!raw-loader!highlight.js/styles/vs.css';
import darkStyles from '!!raw-loader!highlight.js/styles/vs2015.css';

type MarkdownFetcherProps = {
  mdSource: string;
  name: string;
  github?: string;
  nuget?: string;
  docs?: string;
};

const GithubIcon = <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
	<rect width="24" height="24" fill="none" />
	<path fill="currentColor" d="M12 2A10 10 0 0 0 2 12c0 4.42 2.87 8.17 6.84 9.5c.5.08.66-.23.66-.5v-1.69c-2.77.6-3.36-1.34-3.36-1.34c-.46-1.16-1.11-1.47-1.11-1.47c-.91-.62.07-.6.07-.6c1 .07 1.53 1.03 1.53 1.03c.87 1.52 2.34 1.07 2.91.83c.09-.65.35-1.09.63-1.34c-2.22-.25-4.55-1.11-4.55-4.92c0-1.11.38-2 1.03-2.71c-.1-.25-.45-1.29.1-2.64c0 0 .84-.27 2.75 1.02c.79-.22 1.65-.33 2.5-.33s1.71.11 2.5.33c1.91-1.29 2.75-1.02 2.75-1.02c.55 1.35.2 2.39.1 2.64c.65.71 1.03 1.6 1.03 2.71c0 3.82-2.34 4.66-4.57 4.91c.36.31.69.92.69 1.85V21c0 .27.16.59.67.5C19.14 20.16 22 16.42 22 12A10 10 0 0 0 12 2" />
</svg>
const DocsIcon = <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
	<rect width="24" height="24" fill="none" />
	<path fill="currentColor" d="M19 18H9a2 2 0 0 1-2-2V4a2 2 0 0 1 2-2h1v5l2-1.5L14 7V2h5a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2m-2 2v2H5a2 2 0 0 1-2-2V6h2v14z" />
</svg>;
const NugetIcon = <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 512 512">
	<rect width="512" height="512" fill="none" />
	<path fill="currentColor" d="M219.023 70.401H371.2c77.762 0 140.8 63.038 140.8 140.8v152.177c0 77.762-63.038 140.8-140.8 140.8H219.023c-77.761 0-140.8-63.038-140.8-140.8V211.201c0-77.762 63.039-140.8 140.8-140.8m-119.466-12.8c0-38.178-41.613-62.168-74.724-43.08s-33.11 67.07 0 86.16s74.724-4.903 74.724-43.08m142.22 139.377c0-40.377-43.99-65.75-78.991-45.561s-35.002 70.934 0 91.123s78.992-5.184 78.992-45.562M448 363.378c0-69.823-76.092-113.7-136.636-78.788s-60.545 122.665 0 157.576S448 433.201 448 363.378" />
</svg>;

function MarkdownContent({ sourceUrl }: { sourceUrl: string }) {
  const {
    colorMode, // the "effective" color mode, never null
  } = useColorMode();

  const markdown = useMarkdownResource(sourceUrl);
  return (

    <div>
      <style>
        {colorMode === "dark" ? darkStyles : lightStyles}
      </style>
      <Markdown
        remarkPlugins={[remarkGfm, remarkDirective]}
        rehypePlugins={[
          rehypeRaw, 
          [rehypeHighlight, {languages: {...common, fsharp}, aliases: {'fsharp': 'fs'}}]
        ]}
      >
        {markdown.markdown}
      </Markdown>
    </div>
  );
}

function useMarkdownResource(url: string) {
  const [markdown, setMarkdown] = React.useState(null as string | null);
  const [error, setError] = React.useState(null as string | null);
  useEffect(() => {
    fetch(url)
      .then((response) => {
        if (!response.ok) {
          throw new Error(`Failed to fetch markdown from ${url}`);
        }
        return response.text();
      })
      .then(setMarkdown)
      .catch((err) => setError(err.message));
  }, [url]);

  return {
    markdown,
    error,
  }
}

function ExternalLink({icon, ...props}) {
  return (
    <a className={styles.icon} target="_blank" rel="noopener noreferrer" {...props}>
      {icon}
    </a>
  );
}

export default function MarkdownFetcher({ mdSource, name, github, docs, nuget }: MarkdownFetcherProps) {
  
  return (
    <div>
      <div className={styles.header}>
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 16 16">
	<rect width="16" height="16" fill="none" />
	<path fill="currentColor" d="M0 1.75C0 .784.784 0 1.75 0h12.5C15.216 0 16 .784 16 1.75v12.5A1.75 1.75 0 0 1 14.25 16h-8.5a.75.75 0 0 1 0-1.5h8.5a.25.25 0 0 0 .25-.25V6.5h-13v1.75a.75.75 0 0 1-1.5 0ZM6.5 5h8V1.75a.25.25 0 0 0-.25-.25H6.5Zm-5 0H5V1.5H1.75a.25.25 0 0 0-.25.25Z" />
	<path fill="currentColor" d="M1.5 13.737a2.25 2.25 0 0 1 2.262-2.25L4 11.49v1.938c0 .218.26.331.42.183l2.883-2.677a.25.25 0 0 0 0-.366L4.42 7.89a.25.25 0 0 0-.42.183V9.99l-.23-.001A3.75 3.75 0 0 0 0 13.738v1.012a.75.75 0 0 0 1.5 0z" />
</svg>
        <span className={styles.title}>{name}</span>
        <div className={styles.iconContainer}>
          { github && <ExternalLink href={github} icon={GithubIcon} title="GitHub repository" /> }
          { docs && <ExternalLink href={docs} icon={DocsIcon} title="Documentation" /> }
          { nuget && <ExternalLink href={nuget} icon={NugetIcon} title="NuGet package" /> }
        </div>
      </div>

      <Suspense fallback={<div><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
	<rect width="24" height="24" fill="none" />
	<path fill="currentColor" d="M12 2A10 10 0 1 0 22 12A10 10 0 0 0 12 2Zm0 18a8 8 0 1 1 8-8A8 8 0 0 1 12 20Z" opacity="0.5" />
	<path fill="currentColor" d="M20 12h2A10 10 0 0 0 12 2V4A8 8 0 0 1 20 12Z">
		<animateTransform attributeName="transform" dur="1s" from="0 12 12" repeatCount="indefinite" to="360 12 12" type="rotate" />
	</path>
</svg> Loading markdown...</div>}>
        <MarkdownContent sourceUrl={mdSource}/>
      </Suspense>
    </div>
  );
}
