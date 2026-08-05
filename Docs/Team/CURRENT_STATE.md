# Estado operativo actual

**Actualizado:** 2026-08-04  
**Rama:** `main`  
**Upstream:** `origin/main`  
**Base anterior a la activación:** `788d6a2`  
**Fase:** Fase 1 — Hito 1, baseline seguro

## Estado del equipo

- Jerarquía activa: Gabriel → Codex orquestador → especialistas.
- Perfiles configurados: `unreal_gameplay`, `unreal_world_builder`, `ui_presentation`, `netcode_persistence`, `world_economy`, `qa_release_guard`.
- Máximo simultáneo: tres subagentes.
- El orquestador es el único escritor de memoria e integrador.
- Los perfiles persistentes pueden requerir una nueva tarea o recarga de Codex para ser descubiertos; en la tarea actual la delegación explícita ya funciona.

## Decisiones vigentes

- PC, Unreal Engine 5.8.
- Vista top-down confirmada.
- Click-to-move como baseline; teclado se compara en playtest.
- Servidor dedicado autoritativo.
- Vertical slice para 2–8 jugadores.
- Mundo por zonas e instancias.
- Economía de Fase 1: moneda general + divisa ligada; sin trade, subasta, premium o monetización.
- IP original: cambiar nombres de una obra existente no es suficiente.

## Trabajo integrado

- Git/Git LFS inicializado y publicado.
- Assets `.uasset`/`.umap` administrados por LFS.
- Plan de Fase 1 v1.2 disponible.
- Carta multiagente y perfiles Codex preparados en esta tanda.

## Asignaciones y leases activos

No hay tareas de producto ni leases activos al cerrar la configuración del equipo.

| ID | Propietario | Rutas | Lease binario/editor | Estado |
|---|---|---|---|---|
| — | — | — | — | Sin asignaciones |

## Bloqueos conocidos

- Aún no existe target de servidor dedicado.
- Aún no existe módulo de pruebas automatizadas.
- La automatización MCP directa del editor no debe asumirse hasta verificar toolsets disponibles.
- No se ejecutó build/smoke después de activar el equipo; esta tanda solo configura gobernanza.

## Próxima acción exacta

Continuar el Hito 1: asignar al especialista Unreal una auditoría de build de la plantilla y al guardián QA la definición de R0, sin editar simultáneamente los mismos archivos. Luego crear target de servidor dedicado y primer Automation Test mediante tarjetas separadas.

## Cómo retomar

1. Leer `AGENTS.md`, `TEAM_CHARTER.md`, este archivo y el plan de Fase 1.
2. Verificar `git status --short --branch`, `git rev-parse HEAD` y `git lfs status`.
3. Consultar memoria Obsidian si está disponible.
4. Crear una tarjeta desde `TASK_TEMPLATE.md` antes de delegar o escribir.
5. Actualizar este archivo y memoria únicamente después de integrar.
