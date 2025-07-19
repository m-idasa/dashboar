# API Documentation

## GET /api/admin (Admin)
## POST /api/admin/total (Admin)
### Input Parameters:
| Parameter | Type | Required |
|-----------|------|--------|
| from | string | No |
| to | string | No |
| services | array | Yes |
| clients | array | Yes |
| timePeriod | integer | No |

### Sample Request:
```json
{
  "from": "value",
  "to": "value",
  "services": [
    "value"
  ],
  "clients": [
    "value"
  ],
  "timePeriod": "value"
}
```
### Sample Response:
```json
"OK"
```
## GET /api/admin/totalperhour (Admin)
## POST /api/admin/circle (Admin)
### Input Parameters:
| Parameter | Type | Required |
|-----------|------|--------|
| from | string | No |
| to | string | No |
| services | array | Yes |
| clients | array | Yes |
| timePeriod | integer | No |

### Sample Request:
```json
{
  "from": "value",
  "to": "value",
  "services": [
    "value"
  ],
  "clients": [
    "value"
  ],
  "timePeriod": "value"
}
```
### Sample Response:
```json
"OK"
```
## POST /api/admin/line (Admin)
### Input Parameters:
| Parameter | Type | Required |
|-----------|------|--------|
| from | string | No |
| to | string | No |
| services | array | Yes |
| clients | array | Yes |
| timePeriod | integer | No |

### Sample Request:
```json
{
  "from": "value",
  "to": "value",
  "services": [
    "value"
  ],
  "clients": [
    "value"
  ],
  "timePeriod": "value"
}
```
### Sample Response:
```json
"OK"
```
## GET /api/admin/clients (Admin)
### Sample Response:
```json
"OK"
```
## GET /api/admin/services (Admin)
### Sample Response:
```json
"OK"
```
## GET /api/admin/dailylogin (Admin)
### Sample Response:
```json
{
  "service": "value",
  "client": "value",
  "data": [
    "value"
  ]
}
```
## GET /api/admin/logedinusers (Admin)
### Sample Response:
```json
"OK"
```
## GET /api/admin/notlogedinusers (Admin)
### Sample Response:
```json
"OK"
```
## GET /api/admin/sendmessage (Admin)
### Sample Response:
```json
"OK"
```
