Multiple-AI

🇺🇸 English
Overview

A simple C# console application that allows users to select and call multiple AI APIs:

GPT (OpenAI)
Gemini (Google)
Claude (Anthropic)

Users can choose an AI model by number and input a prompt to receive a response.

Features
Multi-AI support (GPT / Gemini / Claude)
Console-based interaction
Async API requests
Easy to extend
Usage
Run the program

Select AI model:

1. GPT
2. Gemini
3. Claude
Enter your prompt
View the response
API Key Setup

Edit Program.cs:

static string GPT_KEY = "OPENAI_KEY";
static string GEMINI_KEY = "GEMINI_KEY";
static string CLAUDE_KEY = "CLAUDE_KEY";

It is recommended to use environment variables instead of hardcoding keys.

Tech Stack
C#
.NET
HttpClient
JSON
Project Structure
Program.cs
README.md
Notes
API models and endpoints may change
Do not expose API keys in public repositories

🇰🇷 한국어
개요

이 프로젝트는 여러 AI API를 선택해서 호출할 수 있는 C# 콘솔 프로그램입니다.

지원 AI:

GPT (OpenAI)
Gemini (Google)
Claude (Anthropic)

번호를 입력하여 AI를 선택하고 프롬프트를 입력하면 응답을 출력합니다.

기능
GPT / Gemini / Claude 지원
콘솔 기반 인터페이스
비동기 API 호출
확장 가능한 구조
사용 방법
프로그램 실행

AI 선택

1. GPT
2. Gemini
3. Claude
프롬프트 입력
결과 확인
API 키 설정

Program.cs에서 설정:

static string GPT_KEY = "OPENAI_KEY";
static string GEMINI_KEY = "GEMINI_KEY";
static string CLAUDE_KEY = "CLAUDE_KEY";

실제 프로젝트에서는 환경 변수 사용을 권장합니다.

기술 스택
C#
.NET
HttpClient
JSON 처리
구조
Program.cs
README.md
주의사항
API는 변경될 수 있습니다
API 키를 GitHub에 올리지 마세요
