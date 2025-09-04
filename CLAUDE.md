# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

This repository contains a master's thesis (Abschlussarbeit) written in LaTeX that focuses on implementing an LLM-based robot feedback framework. The thesis explores the conception and prototypical implementation of a framework for formalizing and methodical investigation of robot feedback systems using Unity3D as a simulation platform.

## Project Structure

```
/
├── Abschlussarbeit.tex        # Main LaTeX document
├── literatur.bib             # Bibliography file
├── Chapter/                  # Thesis chapters
│   ├── 1-Einleitung.tex     # Introduction
│   ├── 2-Grundlagen.tex     # Fundamentals
│   ├── 3-Framework.tex      # Framework implementation
│   ├── 4-Untersuchung.tex   # Investigation/Analysis
│   ├── 5-Ergebnisse.tex     # Results
│   ├── 6-Fazit.tex          # Conclusion
│   └── 3-2-*.tex            # Framework sub-modules
├── Figures/                  # Images and diagrams
├── Includes/                 # LaTeX includes
│   ├── packages.tex         # Package definitions
│   ├── commands.tex         # Custom commands
│   ├── header.tex           # Document header
│   └── titlepage.tex        # Title page
```

## LaTeX Build Process

### Build Commands
- **Main compilation**: `pdflatex Abschlussarbeit.tex`
- **Bibliography**: `biber Abschlussarbeit` or `bibtex Abschlussarbeit`
- **Full build sequence**:
  1. `pdflatex Abschlussarbeit.tex`
  2. `biber Abschlussarbeit`
  3. `pdflatex Abschlussarbeit.tex`
  4. `pdflatex Abschlussarbeit.tex`

### Document Class and Setup
- Uses `scrreprt` (KOMA-Script report class)
- 12pt font, A4 paper, two-sided layout
- Includes table of contents, list of figures, and list of tables
- Bibliography managed with BibLaTeX/Biber

## Framework Architecture (from Chapter 3)

The thesis describes a Unity3D-based robotics safety framework with the following key components:

### Core Architecture Principles
1. **Vendor-Agnostic**: Interface-based architecture abstracting different robot manufacturers
2. **Modular Extensibility**: Plugin system for Safety Monitoring Modules
3. **Real-time Communication**: Low-latency data transmission for motion control

### System Structure
```
RobotSystem/
├── Core/                    # Core system components
│   ├── RobotManager.cs
│   ├── RobotSafetyManager.cs
│   └── SafetyEvent.cs
├── Interfaces/              # Abstract interfaces
│   ├── IRobotConnector.cs
│   └── IRobotSafetyMonitor.cs
├── ABB/                     # ABB-specific implementations
└── Monitors/                # Safety monitoring modules
    ├── CollisionDetectionMonitor.cs
    ├── JointDynamicsMonitor.cs
    └── SingularityDetectionMonitor.cs
```

### Design Patterns Used
- **Observer Pattern**: System-wide event communication
- **Strategy Pattern**: Algorithmic flexibility for different robot types  
- **Adapter Pattern**: Hardware abstraction layer
- **Event-Driven Architecture**: Real-time safety event handling

### Communication Protocols
- HTTPS/HTTP with Digest authentication
- WebSocket Secure (WSS) for real-time bidirectional communication
- XML for structured data with schema validation
- JSON for internal data representation

## Working with This Repository

### Common Tasks
- **Edit thesis content**: Modify files in `Chapter/` directory
- **Add references**: Update `literatur.bib` with new citations
- **Include figures**: Add images to `Figures/` directory
- **Modify layout**: Edit files in `Includes/` directory

### File Dependencies
- Main document includes all chapter files via `\include{}`
- Bibliography references are managed in `literatur.bib`
- Custom commands and packages defined in `Includes/`
- Chapter files may input sub-modules (e.g., `3-2-*.tex` files)

## Development Notes

- The thesis is written in German
- Uses academic citation format with BibLaTeX
- Includes technical diagrams and system architecture documentation
- Framework implementation details are primarily conceptual/architectural rather than full code implementation