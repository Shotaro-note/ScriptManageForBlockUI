\NeedsTeXFormat{pLaTeX2e}
\ProvidesClass{ise-thesis}[2008/01/29 îñVXeHwNX²Æ¤_¶]
% jarticleÌ[hAIvV
\DeclareOption*{\PassOptionsToClass{\CurrentOption}{jbook}}
\ExecuteOptions{12pt}
\ProcessOptions\relax
\LoadClass{jbook}
% pbP[WÌ[h
\RequirePackage{times}
\RequirePackage{graphicx}
\RequirePackage{citesort}

% TZt{SVbNÌ (\sffamilty\gtfamilty)
\newcommand{\gothic}{\sffamily\gtfamily}
\newcommand{\gtfont}[1]{\begingroup\sffamily\gtfamily#1\endgroup}

% itemize Ìx
\renewcommand{\labelitemi}{E}
\renewcommand{\labelitemii}{\scriptsize }
\renewcommand{\labelitemiii}{\scriptsize }
\renewcommand{\labelitemiv}{\scriptsize  }

% Óð«ÌsÔð²ßÂ\É
\newdimen\@LSLen
\newcommand{\liststretch}[1]{\@LSLen #1\p@}
\liststretch{1.0}

\setlength\partopsep{3\@LSLen \@plus 1\@LSLen \@minus 1\@LSLen}
\def\@listi{\leftmargin\leftmargini
  \parsep 4.5\@LSLen \@plus2\@LSLen \@minus\@LSLen
  \topsep 9\@LSLen   \@plus3\@LSLen \@minus5\@LSLen
  \itemsep4.5\@LSLen \@plus2\@LSLen \@minus\@LSLen}
\let\@listI\@listi
\@listi
\def\@listii{\leftmargin\leftmarginii
   \labelwidth\leftmarginii \advance\labelwidth-\labelsep
   \topsep  4.5\@LSLen \@plus2\@LSLen \@minus\@LSLen
   \parsep  2\@LSLen   \@plus\@LSLen  \@minus\@LSLen
   \itemsep\parsep}
\def\@listiii{\leftmargin\leftmarginiii
   \labelwidth\leftmarginiii \advance\labelwidth-\labelsep
   \topsep 2\@LSLen  \@plus\@LSLen\@minus\@LSLen
   \parsep\z@
   \partopsep \@LSLen \@plus\z@ \@minus\@LSLen
   \itemsep\topsep}

% ©oµOãÌsÔð²®Â\É
\newdimen\@SSCvs
\newdimen\@SSCdp
\newdimen\@SSex
\newcommand{\sectionstretch}[1]{%
  \@SSCvs #1\Cvs%
  \@SSCdp #1\Cdp%
  \@SSex #1ex}
\sectionstretch{1.0}

\def\@makechapterhead#1{\hbox{}%
  \vskip2\@SSCvs
  {\parindent\z@
   \raggedright
   \reset@font\huge\gothic
   \leavevmode
   \ifnum \c@secnumdepth >\m@ne
     \setlength\@tempdima{\linewidth}%
    \if@mainmatter
     \setbox\z@\hbox{\@chapapp\thechapter\@chappos\hskip1zw}%
     \addtolength\@tempdima{-\wd\z@}%
     \unhbox\z@\nobreak
    \fi
     \vtop{\hsize\@tempdima#1}%
   \else
     #1\relax
   \fi}\nobreak\vskip3\@SSCvs}
\def\@makeschapterhead#1{\hbox{}%
  \vskip2\@SSCvs
  {\parindent\z@
   \raggedright
   \reset@font\huge\gothic
   \leavevmode
   \setlength\@tempdima{\linewidth}%
   \vtop{\hsize\@tempdima#1}}\vskip3\@SSCvs}
\renewcommand{\section}{\@startsection{section}{1}{\z@}%
   {1.5\@SSCvs \@plus.5\@SSCvs \@minus.2\@SSCvs}%
   {.5\@SSCvs \@plus.3\@SSCvs}%
   {\reset@font\Large\gothic}}
\renewcommand{\subsection}{\@startsection{subsection}{2}{\z@}%
   {1.5\@SSCvs \@plus.5\@SSCvs \@minus.2\@SSCvs}%
   {.5\@SSCvs \@plus.3\@SSCvs}%
   {\reset@font\large\gothic}}
\renewcommand{\subsubsection}{\@startsection{subsubsection}{3}{\z@}%
   {1.5\@SSCvs \@plus.5\@SSCvs \@minus.2\@SSCvs}%
   {.5\@SSCvs \@plus.3\@SSCvs}%
   {\reset@font\normalsize\gothic}}
\renewcommand{\paragraph}{\@startsection{paragraph}{4}{\z@}%
   {3.25\@SSex \@plus 1\@SSex \@minus .2\@SSex}%
   {-1em}%
   {\reset@font\normalsize\gothic}}
\renewcommand{\subparagraph}{\@startsection{subparagraph}{5}{\z@}%
   {3.25\@SSex \@plus 1\@SSex \@minus .2\@SSex}%
   {-1em}%
   {\reset@font\normalsize\gothic}}

% pTCYÌÝèR}h
\def\paperSize#1#2{%
  \@paperWidth0pt\@paperHeight0pt%
  \edef\@paperSize{#1}%
  \def\@sizeName{a3}
  \ifx\@paperSize\@sizeName\@paperWidth296mm\@paperHeight420mm\fi%
  \def\@sizeName{a4}
  \ifx\@paperSize\@sizeName\@paperWidth210mm\@paperHeight296mm\fi%
  \def\@sizeName{a5}
  \ifx\@paperSize\@sizeName\@paperWidth148mm\@paperHeight210mm\fi%
  \def\@sizeName{a6}
  \ifx\@paperSize\@sizeName\@paperWidth105mm\@paperHeight148mm\fi%
  \def\@sizeName{b4}
  \ifx\@paperSize\@sizeName\@paperWidth257mm\@paperHeight363mm\fi%
  \def\@sizeName{b5}
  \ifx\@paperSize\@sizeName\@paperWidth181mm\@paperHeight257mm\fi%
  \def\@sizeName{letter}
  \ifx\@paperSize\@sizeName\@paperWidth8.5in\@paperHeight11in\fi%
  \def\@sizeName{a4r}
  \ifx\@paperSize\@sizeName\@paperWidth296mm\@paperHeight210mm\fi%
  \def\@sizeName{a5r}
  \ifx\@paperSize\@sizeName\@paperWidth210mm\@paperHeight148mm\fi%
  \def\@sizeName{a6r}
  \ifx\@paperSize\@sizeName\@paperWidth148mm\@paperHeight105mm\fi%
  \def\@sizeName{b4r}
  \ifx\@paperSize\@sizeName\@paperWidth363mm\@paperHeight257mm\fi%
  \def\@sizeName{b5r}
  \ifx\@paperSize\@sizeName\@paperWidth257mm\@paperHeight181mm\fi%
  \def\@sizeName{letterr}
  \ifx\@paperSize\@sizeName\@paperWidth11in\@paperHeight8.5in\fi%
  \def\@sizeName{envK2}		% p2
  \ifx\@paperSize\@sizeName\@paperWidth240mm\@paperHeight332mm\fi%
  \def\@sizeName{envT3}		% ·3
  \ifx\@paperSize\@sizeName\@paperWidth120mm\@paperHeight235mm\fi%
  \def\@sizeName{envT3r}		% ·3¡
  \ifx\@paperSize\@sizeName\@paperWidth235mm\@paperHeight120mm\fi%
  \ifdim\@paperWidth=0pt\typein{unknown paper size : #1}\fi%
  #2
  % \topmargin = \topMargin - \headheight - \headsep
  \setlength{\topmargin}{\topMargin}%
  \addtolength{\topmargin}{-\headheight}%
  \addtolength{\topmargin}{-\headsep}%
  \addtolength{\topmargin}{-1in}%
  % \textheight = \@paperWidth - \topMargin - \bottomMargin
  \setlength{\textheight}{\@paperHeight}%
  \addtolength{\textheight}{-\topMargin}%
  \addtolength{\textheight}{-\bottomMargin}%
  % \oddsidemargin = \insideMargin
  \setlength{\oddsidemargin}{\insideMargin}%
  \addtolength{\oddsidemargin}{-1in}%
  % \evensidemargin = \outsideMargin
  \setlength{\evensidemargin}{\outsideMargin}%
  \addtolength{\evensidemargin}{-1in}%
  % \textwidth = \@paperWidth - \insideMargin - \outsideMargin
  \setlength{\textwidth}{\@paperWidth}%
  \addtolength{\textwidth}{-\insideMargin}
  \addtolength{\textwidth}{-\outsideMargin}
}

% }[WÝèpÌ·³Ï
\newlength{\@paperWidth}
\newlength{\@paperHeight}
\newlength{\topMargin}
\newlength{\bottomMargin}
\newlength{\insideMargin}
\newlength{\outsideMargin}

% ftHgpÝè
\paperSize{a4}{%
  \topMargin 30mm
  \bottomMargin 30mm
  \insideMargin 25mm
  \outsideMargin 22mm
  \headheight 10mm
  \headsep 5mm
  \footskip 10mm
}

% y[WX^C
\pagestyle{plain}

% sÔ²®
\renewcommand{\baselinestretch}{1.05}

\newif\ifmast

\def\bachelor{1}\def\master{2}
\def\thesis#1{
\if#1\bachelor
  \def\thesistitle{²Æ¤_¶}
  \def\ethesistitle{Bachelor Thesis}
  \def\affiliation{kåw Hw îñm\VXewÈ}
   \mastfalse
\else
  \def\thesistitle{åw@mOúÛöCmwÊ_¶}
  \def\ethesistitle{Master Thesis}
  \def\affiliation{åãåw åw@Hw¤È \\ îñVXeHwêU}
  \masttrue
\fi
}

\def\title#1{\gdef\@title{#1}}
\def\etitle#1{\gdef\@etitle{#1}}
\def\author#1{\gdef\@author{#1}}
\def\eauthor#1{\gdef\@eauthor{#1}}
\def\supervisor#1{\gdef\@supervisor{#1}}
\def\esupervisor#1{\gdef\@esupervisor{#1}}
\def\deadline#1{\gdef\@deadline{#1}}
\long\def\abstract#1{\long\gdef\@abstract{#1}}
\long\def\eabstract#1{\long\gdef\@eabstract{#1}}
\def\keyword#1{\gdef\@keyword{#1}}
\def\ekeyword#1{\gdef\@ekeyword{#1}}

\def\coverpage{\newpage\null
\thispagestyle{empty}
\vspace*{\fill}
\begin{center}
{\Large\gothic\thesistitle}\\
\vspace*{20mm}
{\large è~~~~~Ú}\\
\vspace*{5mm}
{\Large\gothic\@title}\\
\vspace*{30mm}
w±³õ\\ \@supervisor\\
\vspace*{20mm}
ñÒ \\ \@author\\
\vspace*{15mm}
\@deadline\\
\vspace*{15mm}
\affiliation\\
\end{center}
\vspace*{\fill}
\newpage
\pagenumbering{roman}
\begin{flushleft}\thesistitle\end{flushleft}
\vspace*{2mm}
\begin{flushleft}{\large \@title}\end{flushleft}
\begin{flushright}\@author\end{flushright}
\vspace*{2mm}
\begin{flushleft}{\gothic àe[T}\\ \end{flushleft}
\vspace*{2mm}

\@abstract
\vspace*{5mm}
\begin{flushleft}{\gothic L[[h}\\ \end{flushleft}
\@keyword
\ifmast
  \newpage
  \begin{flushleft}\ethesistitle\end{flushleft}
  \vspace*{2mm}
  \begin{flushleft}{\large \@etitle}\end{flushleft}
  \begin{flushright}\@eauthor\end{flushright}
  \vspace*{2mm}
  \begin{flushleft}{\bf Abstract}\\ \end{flushleft}
  \vspace*{2mm}
  \@eabstract
  \vspace*{5mm}
  \begin{flushleft}{\bf Keywords}\\ \end{flushleft}
  \@ekeyword
\fi
}

\newcommand{\body}{\newpage\pagenumbering{arabic}}
\newcommand{\acknowledgement}{
        \chapter*{Ó«\addcontentsline{toc}{chapter}{Ó«}}}
\def\thebibliography#1{\chapter*{Ql¶£\@mkboth
 {Q l ¶ £}{Q l ¶ £}\addcontentsline{toc}{chapter}{Ql¶£}}\list
 {[\arabic{enumi}]}{\settowidth\labelwidth{[#1]}\leftmargin\labelwidth
 \advance\leftmargin\labelsep
 \usecounter{enumi}}
 \def\newblock{\hskip .11em plus .33em minus .07em}
 \sloppy
 \sfcode`\.=1000\relax}
\let\endthebibliography=\endlist
\def\appendix{\@ifnextchar[{\@appendix}{\@appendix[]}}
\def\@appendix[#1]{\chapter*{t^#1\addcontentsline{toc}{chapter}{t^#1}}}

\title{}
\etitle{}
\author{}
\eauthor{}
\supervisor{}
\esupervisor{}
\deadline{Nú}
\abstract{}
\eabstract{}
\keyword{}
\ekeyword{}
